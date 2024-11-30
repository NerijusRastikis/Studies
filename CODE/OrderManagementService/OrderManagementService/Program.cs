
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderManagementService.Database;

namespace OrderManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OMS_ApiKey",
                    Version = "v1"

                });

                opt.AddSecurityDefinition("X-API-KEY", new OpenApiSecurityScheme
                {
                    Description = "Task given by Robertas in collaboration with chatGPT!",
                    Name = "X-API-KEY",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "X-API-KEY"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            builder.Services.AddDbContext<OrderDB>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("Database")
               )
            );

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
