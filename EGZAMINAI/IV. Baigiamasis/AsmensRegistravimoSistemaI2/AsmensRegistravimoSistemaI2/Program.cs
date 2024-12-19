using AsmensRegistravimoSistemaI2.Database;
using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.Database.Repositories;
using AsmensRegistravimoSistemaI2.Mappers;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Services;
using AsmensRegistravimoSistemaI2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AsmensRegistravimoSistemaI2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ARSDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("Database")));

            // Dependency Injection
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IJwtService, JwtService>();
            builder.Services.AddTransient<IPhoneNumberConverter, PhoneNumberConverter>();

            builder.Services.AddTransient<IUserMapper, UserMapper>();
            builder.Services.AddTransient<IGeneralInformationMapper, GeneralInformationMapper>();
            builder.Services.AddTransient<IAddressMapper, AddressMapper>();

            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IGIRepository, GIRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = int.MaxValue;
            });

            // Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Add Controllers
            builder.Services.AddControllers();

            // Swagger setup with JWT support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.OperationFilter<FileUploadOperationFilter>();

                // Add JWT Bearer authentication support in Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer {your JWT token}'"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors("AllowAllOrigins");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Add Authentication and Authorization middlewares
            app.UseAuthentication(); // Important: Call this before UseAuthorization
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
