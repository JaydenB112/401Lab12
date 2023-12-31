using Lab12.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace Lab12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews().AddJsonOptions(o => {
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

                o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
              
            });
            builder.Services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "School Demo",
                    Version = "v1",
                });
            });

            builder.Services.AddDbContext<AsyncInnContext>(options =>

            options.UseSqlServer(builder.Configuration

            .GetConnectionString("DefaultConnection")));
           

            var app = builder.Build();
            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            //app.MapGet("/", () => "Hello World!");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{cotroller=Home}/{action=Index}/{id?}");

            // https://localhost:33491/Hotel/CheckIn/1
            app.Run();
        }
    }
}