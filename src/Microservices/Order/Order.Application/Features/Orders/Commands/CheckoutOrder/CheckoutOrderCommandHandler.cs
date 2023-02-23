namespace Order.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderModel = _mapper.Map<Ordered>(request);
            var newOrder = await _orderRepository.AddAsync(orderModel);
            await SendMail(newOrder);

            return newOrder.Id;

        }

        private async Task SendMail(Ordered ordered)
        {
            var email = new Email() { To = "pokohon888@minterp.com", Object = "Votre nouvelle commande", Body = "Cher Client Blablabla" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Commande {ordered.Id} échouer à cause de l'erreur {ex.Message}");
            }
        }
    }
}
