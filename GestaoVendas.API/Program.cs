using GestaoVendas.API.Extensions;
using GestaoVendas.API.Middlewares;
using GestaoVendas.Domain.Extensions;
using GestaoVendas.Infra.Data.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddRouting(map => map.LowercaseUrls = true);

builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);

builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainService();

var app = builder.Build();

app.MapOpenApi();

app.UseSwaggerDoc();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
