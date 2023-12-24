
using Innoplatform.Api.Extensions;
using Innoplatform.Api.Middlewares;
using Innoplatform.Api.Models;
using Innoplatform.Data.DbContexts;
using Innoplatform.Service.Helpers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomService();

builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddSwaggerService();

//DB

builder.Services.AddDbContext<AppDbContext>(option
=> option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Cycle solution
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

//Configure api url name
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                        new ConfigurationApiUrlName()));
});

var app = builder.Build();
WebEnvironmentHost.WebRootPath = Path.GetFullPath("wwwroot");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
