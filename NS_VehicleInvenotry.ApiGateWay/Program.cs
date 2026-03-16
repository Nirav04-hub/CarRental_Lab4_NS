using NS_VehicleInvenotry.ApiGateWay.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseMiddleware<NS_GlobalExceptionMiddleware>();
app.UseMiddleware<NS_ApiKeyAuthMiddleware>();

app.MapReverseProxy();

app.Run();