namespace Order.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ordered, OrdersVm>().ReverseMap();
            CreateMap<Ordered, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Ordered, UpdateOrderCommand>().ReverseMap();
        }
    }
}
