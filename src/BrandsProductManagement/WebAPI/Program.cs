using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .SetIsOriginAllowed(_ => true)  
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();  
    });
});

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerConfig();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "BrandsProductResponse API v1");
    });
}
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.ConfigureCustomExtensionMiddleware();
app.UseHttpsRedirection();



app.Run();

