var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot().AddCacheManager(options =>
{
    options.WithDictionaryHandle();
});

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();
