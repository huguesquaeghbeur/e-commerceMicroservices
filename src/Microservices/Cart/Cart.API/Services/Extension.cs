namespace Cart.API.Services
{
    public static class Extension
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<DiscountConsumer>();

            services.AddAutoMapper(typeof(Program));

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
