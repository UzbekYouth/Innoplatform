
using Innoplatform.Api.Extensions;
using Innoplatform.Api.Middlewares;
using Innoplatform.Data.DbContexts;
using Innoplatform.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace Innoplatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCustomService();
            builder.Services.AddDbContext<AppDbContext>(option
            => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

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
        }
    }
}