namespace User.API.Services
{
    public static class Extension
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddDbContext<ClientDataContext>();
            services.AddScoped<IClientRepository<Client>, ClientRepository>();
            services.AddTransient<LoginService>();
        
            services.AddCors(options =>
            {
                options.AddPolicy("specialOrigin", builder =>
                {
                    builder.WithMethods("GET", "POST", "UPDATE", "DELETE").WithOrigins("http://localhost:3000");
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("azerty123:superSecure")),
                    ValidateIssuer = true,
                    ValidIssuer = "hugs@2023",
                    ValidateAudience = true,
                    ValidAudience = "hugs@2023"
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", police =>
                {
                    police.RequireClaim(ClaimTypes.Role, "admin");
                });
            });
        }
    }
}
