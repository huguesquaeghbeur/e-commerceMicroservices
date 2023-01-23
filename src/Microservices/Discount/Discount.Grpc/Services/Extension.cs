namespace Discount.Grpc.Services
{
    public static class Extension
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddAutoMapper(typeof(Program));
            services.AddCors(options =>
            {
                options.AddPolicy("allconnections", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryAvaibility = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating mysql database!");
                    using var connection = new MySqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new MySqlCommand
                    {
                        Connection = connection
                    };

                    command.CommandText = "DROP TABLE IF EXISTS coupon";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE coupon (id SERIAL PRIMARY KEY, productname VARCHAR(24) NOT NULL, description TEXT, amount INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO coupon (productname, description, amount) VALUES ('IPhone X', 'IPhone discount', 150)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO coupon (productname, description, amount) VALUES ('Samsung 10', 'Samsung discount', 100)";
                    command.ExecuteNonQuery();

                    logger.LogInformation("Migration succeded ");
                }
                catch (MySqlException excep)
                {
                    logger.LogError(excep, "An error occured");

                    if (retryAvaibility < 50)
                    {
                        retryAvaibility++;
                        Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryAvaibility);
                    }
                }
                return host;
            }
        }
    }
}
