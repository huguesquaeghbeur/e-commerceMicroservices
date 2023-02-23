namespace Order.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var updateOrder = await _orderRepository.GetByIdAsync(request.Id);
            if (updateOrder == null)
            {
                throw new NotFoundException(nameof(Ordered), request.Id);
            }
            _mapper.Map(request, updateOrder);
            await _orderRepository.UpdateAsync(updateOrder);
            return Unit.Value;
        }
    }
}
