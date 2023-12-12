namespace Cart.API.Interfaces
{
    public interface ICartRepository
    {
        Task<CartShopping> GetCart(string email);
        Task<CartShopping> UpdateCart(CartShopping cart);
        Task DeleteCart(string email);
    }
}
