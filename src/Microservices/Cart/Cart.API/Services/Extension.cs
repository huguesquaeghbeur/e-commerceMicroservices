namespace Cart.API.Services
{
    public static class Extension
    {
        // IConfiguration aller chercher la ConnectionString dans appsettings
        
        public static IConfiguration Config { get; }
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            
            // Config Redis
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "cartdb:6379";
            //});

            // Grpc consumer
            //services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
            //{
            //    options.Address = new Uri("http://discount.grpc");
            //});
            services.AddScoped<DiscountConsumer>();

            services.AddMassTransit(options =>
            {
                options.UsingRabbitMq((context, config) =>
                {
                    //config.Host(new Uri("rabbitmq://localhost:5672"), host =>
                    //{
                    //    host.Username("guest");
                    //    host.Password("guest");
                    //});
                    // Simplifier en
                    config.Host("rabbitmq://guest:guest@localhost:5672");
                });
            });
            //services.AddMassTransitHostedService();

            services.AddCors(options =>
            {
                options.AddPolicy("allconnection", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}
