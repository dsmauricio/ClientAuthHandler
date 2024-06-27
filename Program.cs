using ClientAuthHandler.Handlers;
using ClientAuthHandler.Interfaces;
using ClientAuthHandler.Services;
using ClientAuthHandler.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddOptions<GraphSettings>()
    .BindConfiguration("GraphApiAuth");

builder.Services.AddHttpClient<IAuthService, GraphAuthService>();
builder.Services.AddTransient<AuthTokenHandler>();
builder.Services.Decorate<IAuthService, CachedGraphAuthService>();

builder.Services.AddHttpClient<IGraphApiService, GraphApiService>(client =>
{
    client.BaseAddress = new Uri("https://graph.microsoft.com/v1.0/");
})
.AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
