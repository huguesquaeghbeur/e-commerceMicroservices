namespace Cart.API.Services
{
    public static class Extension
    {
        // IConfiguration aller chercher la ConnectionString dans appsettings
        //public static IConfiguration Config { get; }
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "cartdb:6379";
            });
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
