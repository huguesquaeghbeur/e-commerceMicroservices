

namespace Order.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Ordereds.Any())
            {
                orderContext.Ordereds.AddRange(GetPreconfiguredOrdereds());
                await orderContext.SaveChangesAsync();
                logger.LogInformation(typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Ordered> GetPreconfiguredOrdereds()
        {
            return new List<Ordered>
            {
                new Ordered()
                {
                    UserName = "Toto",
                    FirstName = "Hector",
                    LastName = "Tramor",
                    Email = "pokohon888@minterp.com",
                    Address = "28 rue du stade",
                    City = "Bastia",
                    ZipCode = "20100",
                    Country = "Corsica",
                    TotalPrice = 798
                }
            };
        }
    }
}
