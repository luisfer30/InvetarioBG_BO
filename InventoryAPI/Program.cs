using InventoryAPI.Dependencies;
using InventoryAPI.Middlewares;
using InventoryRepository.Dependencies;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.LoggerDI(builder.Configuration);

builder.Services.AuthenticationDI(builder.Configuration);

builder.Services.AuthorizationDI();

builder.Services.CORSDI();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.SwaggerDocumentationDI();

builder.Services.RepositoriesDI(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API v1");
    });
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("InventoryOrigins");

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Use( async(context, next) =>
{
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
    await next();
});

await app.RunAsync();