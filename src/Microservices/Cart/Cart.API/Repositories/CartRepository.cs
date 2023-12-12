namespace Cart.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        // Nécessite l'extension Microsoft.Extensions.Caching.Distributed pour cache redis
        private readonly IDistributedCache _redisCache;

        public CartRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<CartShopping> GetCart(string email)
        {
            var cart = await _redisCache.GetStringAsync(email);
            if (cart == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<CartShopping>(cart);
        }

        public async Task<CartShopping> UpdateCart(CartShopping cart)
        {
            // Récupére la clé/valeur de redis
            await _redisCache.SetStringAsync(cart.Email, JsonConvert.SerializeObject(cart));
            // On envoie la valeur du panier en utilisant la clé
            return await GetCart(cart.Email);
        }

        public async Task DeleteCart(string email)
        {
            await _redisCache.RemoveAsync(email);
        }
    }
}
