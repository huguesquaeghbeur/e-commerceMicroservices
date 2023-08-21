namespace Ordered.API.Data
{
    public class OrderedContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        private readonly string _connectionString;

        public OrderedContext(IConfiguration configuration)
        {
            //Pour créer la DB =>  / opt / mssql - tools / bin / sqlcmd - S localhost - U sa - P SqlServer!1 + CREATE DATABASE orderdb +GO
            _connectionString = configuration.GetConnectionString("OrderDataContext");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
