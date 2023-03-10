var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOurServices();
// Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = config.GetValue<string>("CacheSettings:ConnectionString");
});
// Server Grpc
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(config["GrpcSettings:DiscountUrl"]);
});
// Mass Transit
builder.Services.AddMassTransit(options =>
{
    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(config["EventBusSettings:HostAddress"]);
    });
});
//builder.Services.AddMassTransitHostedService();

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

app.Run();
