namespace Cart.API.Controllers
{
    [Route("api/v1/cart")]
    [EnableCors("allconnections")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly DiscountConsumer _discountConsumer;

        public CartController(ICartRepository cartRepository, DiscountConsumer discountConsumer)
        {
            _cartRepository = cartRepository;
            _discountConsumer = discountConsumer;
        }

        [HttpGet("{userName}", Name = "getcart")]
        public async Task<ActionResult<CartShopping>> GetCart(string userName)
        {
            var cart = await _cartRepository.GetCart(userName);
            return Ok(cart ?? new CartShopping(userName));
        }

        [HttpPost]
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

        [HttpDelete("{userName}", Name = "deletebasket")]
        public async Task<IActionResult> DeleteCart(string userName)
        {
            await _cartRepository.DeleteCart(userName);
            return Ok();
        }

    }
}
