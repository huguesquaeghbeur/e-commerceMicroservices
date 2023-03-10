namespace Cart.API.Mapper
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartCheckout, CartCheckoutEvent>().ReverseMap();
        }
    }
}
