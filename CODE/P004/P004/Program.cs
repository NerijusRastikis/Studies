
using Microsoft.Extensions.DependencyInjection;
using P0004.Models;
using P0004.Services;

namespace P0004
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IBooksAPIClient, BooksAPIClient>();
            builder.Services.AddTransient<IBooksMapper, BooksMapper>();

            // Add HTTP Client service

            builder.Services.AddHttpClient<IBooksAPIClient, BooksAPIClient>((services, client) =>
            {
                var config = builder.Configuration.GetSection("BooksAPI").Get<BooksAPIConfig>();
                client.BaseAddress = new Uri(config.Url);
                client.DefaultRequestHeaders.Add("X-API-KEY", config.APIKey);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<BooksAPIConfig>(builder.Configuration.GetSection("BooksAPI"));

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
