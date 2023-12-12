namespace Cart.API.Controllers
{
    [Route("api/v1/cart")]
    [EnableCors("allconnections")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly DiscountConsumer _discountConsumer;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CartController(ICartRepository cartRepository, DiscountConsumer discountConsumer, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _cartRepository = cartRepository;
            _discountConsumer = discountConsumer;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("{email}")]
        [ProducesResponseType(typeof(CartShopping), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CartShopping>> GetCart(string email)
        {
            var cart = await _cartRepository.GetCart(email);
            return Ok(cart ?? new CartShopping(email));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CartShopping), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CartShopping>> UpdateCart([FromBody] CartShopping cart)
        {
            //Consommer DiscountConsumer
            foreach (var item in cart.Items)
            {
                var coupon = await _discountConsumer.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
            return Ok(await _cartRepository.UpdateCart(cart));
        }

        [HttpDelete("{email}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCart(string email)
        {
            await _cartRepository.DeleteCart(email);
            return Ok();
        }

        [Route("checkout")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] CartCheckout cartCheckout)
        {
            var cart = await _cartRepository.GetCart(cartCheckout.Email);
            if (cart == null)
            {
                return BadRequest();
            }

            var eventMessage = _mapper.Map<CartCheckoutEvent>(cartCheckout);
            eventMessage.TotalPrice = cart.Totalprice;
            await _publishEndpoint.Publish(eventMessage);
            //_eventBus.PublishCartCheckout

            await _cartRepository.DeleteCart(cart.Email);

            return Accepted();
        }

    }
}
