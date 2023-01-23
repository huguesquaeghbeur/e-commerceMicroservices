namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public override async Task<CouponDto> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _discountRepository.GetDiscount(request.ProductName);
            if (coupon != null)
            {
                var couponDto = _mapper.Map<CouponDto>(coupon);
                return couponDto;
            }
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName}"));
        }

        public override async Task<CouponDto> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _discountRepository.CreateDiscount(coupon);
            var couponDto = _mapper.Map<CouponDto>(coupon);
            return couponDto;
        }

        public override async Task<CouponDto> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _discountRepository.UpdateDiscount(coupon);
            var couponDto = _mapper.Map<CouponDto>(coupon);
            return couponDto;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _discountRepository.DeleteDiscount(request.ProductName);
            var response = new DeleteDiscountResponse { Success = deleted };
            return response;
        }
    }
}
