namespace Order.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand> 
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var deleteOrder = await _orderRepository.GetByIdAsync(request.Id);
            if (deleteOrder == null)
            {
                throw new NotFoundException(nameof(Ordered), request.Id);
            }
            await _orderRepository.DeleteAsync(deleteOrder);
            return Unit.Value;
        }
    }
}
