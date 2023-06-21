namespace User.API.Data
{
    public class ClientDataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        private readonly string _connectionString;

        public ClientDataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ClientDataContext");
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
