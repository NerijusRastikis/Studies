
using Microsoft.OpenApi.Models;
using P103_ExternalApi.Models;
using P103_ExternalApi.Services;
using System.Reflection;

namespace P103_ExternalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IBooksApiClient, BooksApiClient>();
            builder.Services.AddTransient<IBooksMapper, BooksMapper>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mokomoji Aplinka apie API naudojimą",
                    Description = "Apibūdinimas",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
            });            

            // Register HttpClient for BooksApiClient
            builder.Services.AddHttpClient<IBooksApiClient, BooksApiClient>((services, client) =>
            {
                var config = builder.Configuration.GetSection("BooksApi").Get<BooksApiConfig>();
                client.BaseAddress = new Uri(config.Url);
                client.DefaultRequestHeaders.Add("X-API-KEY", config.ApiKey);
            });
            //builder.Services.AddHttpClient

            // Register BooksApiConfig
            //builder.Services.Configure<BooksApiConfig>(builder.Configuration.GetSection("BooksApi"));


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
        }
    }
}
