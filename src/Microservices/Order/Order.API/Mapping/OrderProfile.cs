namespace Order.API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutOrderCommand, CartCheckoutEvent>().ReverseMap();
        }
    }
}
