using GestaoVendas.Infra.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEntityFramework(builder.Configuration);

var app = builder.Build();

app.MapOpenApi();
app.UseAuthorization();
app.MapControllers();

app.Run();
