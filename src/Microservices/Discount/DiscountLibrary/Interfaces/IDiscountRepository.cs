namespace Discount.Library.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon element);
        Task<bool> UpdateDiscount(Coupon element);
        Task<bool> DeleteDiscount(string productName);
    }
}
