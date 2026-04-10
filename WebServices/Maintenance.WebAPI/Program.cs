using Maintenance.WebAPI.Middleware;
using Maintenance.WebAPI.Services;
using NS_CarRental.GlobalException;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepairHistoryService, FakeRepairHistoryService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 


var usageCounts = new Dictionary<string, int>();
builder.Services.AddSingleton(usageCounts);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseMiddleware<NS_GlobalExceptionMiddleware>();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();
    
app.MapControllers();

app.Run();
