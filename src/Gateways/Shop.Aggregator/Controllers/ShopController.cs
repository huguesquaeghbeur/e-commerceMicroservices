using Microsoft.AspNetCore.Mvc;

namespace Shop.Aggregator.Controllers
{
    [Route("api/v1/shop")]
    public class ShopController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public ShopController(ICatalogService catalogService, ICartService cartService, IOrderService orderService)
        {
            _catalogService = catalogService;
            _cartService = cartService;
            _orderService = orderService;
        }

        [HttpGet("{userName}", Name = "GetShop")]
        public async Task<ActionResult<ShopModel>> GetShop(string userName)
        {
            var cart = await _cartService.GetCart(userName);

            foreach (var item in cart.Items)
            {
                var product = await _catalogService.GetCatalogById(item.ProductId);

                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var orders = await _orderService.GetOrders(userName);

            var shopModel = new ShopModel
            {
                UserName = userName,
                CartWithProducts = cart,
                Orders = orders
            };
            return Ok(shopModel);
        }
    }
}
