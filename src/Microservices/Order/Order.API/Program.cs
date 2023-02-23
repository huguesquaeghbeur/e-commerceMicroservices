var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOurServices();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
// DB config
builder.Services.AddDbContext<OrderContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("OrderConnectionString"));
});
// SendGrid (email) config
builder.Services.Configure<EmailSettings>(c =>
{
    config.GetSection("EmailSettings");
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

//app.MigrateDatabase<OrderContext>((context, services) =>
//{
//    var log = services.GetService<ILogger<OrderContextSeed>>();
//    OrderContextSeed
//        .SeedAsync(context, log)
//        .Wait();
//});

app.Run();
