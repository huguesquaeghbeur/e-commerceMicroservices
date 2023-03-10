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
// MassTransit
builder.Services.AddMassTransit(options =>
{
    options.AddConsumer<CartCheckoutConsumer>();

    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(config["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstants.CartCheckoutQueue, c =>
        {
            c.ConfigureConsumer<CartCheckoutConsumer>(context);
        });
    });

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

app.Run();
