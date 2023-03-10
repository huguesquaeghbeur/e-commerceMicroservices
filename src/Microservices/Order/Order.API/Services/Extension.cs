namespace Order.API.Services
{
    public static class Extension
    {
        //private static IConfiguration Configuration { get; }
        //public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration Configuration)
        //{
        //    services.Configure<ExtendService>(Configuration);
        //    return services;
        //}
        //public static IConfiguration Configuration { get; }
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices();

            services.AddAutoMapper(typeof(Program));
            services.AddScoped<CartCheckoutConsumer>();

            services.AddCors(options =>
            {
                options.AddPolicy("allconnections", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
 
        }
    }
}
