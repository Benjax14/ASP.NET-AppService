using AppService.Api.RequestResponse.Enums;
using AppService.Api.RequestResponse.Requests;
using AppService.Api.RequestResponse.Response;
using AppService.Api.Tables;
using System.Collections;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AppService1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });


            var app = builder.Build();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();

        }

        
    }
}