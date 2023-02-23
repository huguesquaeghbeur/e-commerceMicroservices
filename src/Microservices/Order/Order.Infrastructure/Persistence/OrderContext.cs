namespace Order.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        public DbSet<Ordered> Ordereds { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Pour créer la DB =>  /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P SqlServer!1 + CREATE DATABASE microservice_user + GO
        //    optionsBuilder.UseSqlServer(@"server = localhost; user id = sa; database = orderdb; password = SqlServer!1; TrustServerCertificate = True");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ModelBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.CreatedBy = "Toto";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Toto";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
