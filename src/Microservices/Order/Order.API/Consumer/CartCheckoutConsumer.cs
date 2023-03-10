namespace Order.API.Consumer
{
    public class CartCheckoutConsumer : IConsumer<CartCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CartCheckoutConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            await _mediator.Send(command);
        }
    }
}
