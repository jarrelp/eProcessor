using Ecmanage.eProcessor.Services.Fetch.API;
using Ecmanage.eProcessor.Services.Fetch.API.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.AddCustomSwagger();
builder.AddCustomHealthChecks();
builder.AddCustomApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
    await app.InitialiseDatabaseAsync();
}

app.UseCloudEvents();
app.UseRouting();

app.MapGet("/", () => Results.LocalRedirect("~/swagger"));
app.MapControllers();
app.MapSubscribeHandler();
app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);

app.Run();


// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//     policy =>
//     {
//         policy.AllowAnyHeader();
//         policy.AllowAnyOrigin();
//         policy.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS", "PATCH", "TRACE", "CONNECT", "HEAD");
//         policy.SetIsOriginAllowed(origin => true);
//     });
// });

// app.UseCors(MyAllowSpecificOrigins);