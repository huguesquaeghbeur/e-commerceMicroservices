
namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new MySqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM coupon WHERE productname = @ProductName", new { ProductName = productName});

            if (coupon == null)
            {
                return new Coupon
                {
                    ProductName = "No discount",
                    Amount = 0,
                    Description = "No discount desc"
                };
            }
            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new MySqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var create = await connection.ExecuteAsync("INSERT INTO coupon ( productname, description, amount) VALUES (@ProductName, @Description, @Amount)", new { coupon.ProductName, coupon.Description, coupon.Amount });

            if ( create > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new MySqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var update = await connection.ExecuteAsync("UPDATE coupon SET productname = @ProductName, description = @Description, amount = @Amount WHERE id = @Id", new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });

            if ( update > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new MySqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var delete = await connection.ExecuteAsync("DELETE FROM coupon WHERE productname = @ProductName", new { ProductName = productName });

            if ( delete > 0 )
            {
                return true;
            }
            return false;
        }


    }
}
