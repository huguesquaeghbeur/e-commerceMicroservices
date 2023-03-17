var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

// Client http
builder.Services.AddHttpClient<ICatalogService, CatalogService>(config =>
{
    config.BaseAddress = new Uri(configuration["ApiSettings:CatalogUrl"]);
});
builder.Services.AddHttpClient<ICartService, CartService>(config =>
{
    config.BaseAddress = new Uri(configuration["ApiSettings:CartUrl"]);
});
builder.Services.AddHttpClient<IOrderService, OrderService>(config =>
{
    config.BaseAddress = new Uri(configuration["ApiSettings:OrderUrl"]);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
