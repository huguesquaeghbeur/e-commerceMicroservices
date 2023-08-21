var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot().AddCacheManager(options =>
{
    options.WithDictionaryHandle();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("allconnections", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("allconnections");

app.UseOcelot().Wait();

app.Run();
