namespace Ordered.API.Services
{
    public static class Extension
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddDbContext<OrderedContext>();
            services.AddScoped<IOrderedRepository, OrderedRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("allConnections", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}
