namespace Order.Infrastructure
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Envoi context vers API pour connection
            //services.AddDbContext<OrderContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("OrderConnectionString")));
            
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Envoi config sendGrid
            //services.Configure<EmailSettings>(c =>
            //{
            //    Configuration.GetSection("EmailSettings");
            //});
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
