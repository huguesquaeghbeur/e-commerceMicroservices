namespace Cart.API.Interfaces
{
    public interface ICartRepository
    {
        Task<CartShopping> GetCart(string UserName);
        Task<CartShopping> UpdateCart(CartShopping cart);
        Task DeleteCart(string UserName);
    }
}
