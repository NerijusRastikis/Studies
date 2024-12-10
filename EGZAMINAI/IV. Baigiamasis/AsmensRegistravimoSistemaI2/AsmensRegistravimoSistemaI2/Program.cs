
using AsmensRegistravimoSistemaI2.Database;
using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.Database.Repositories;
using AsmensRegistravimoSistemaI2.Mappers;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Services;
using AsmensRegistravimoSistemaI2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserMapper, UserMapper>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IImageMapper, ImageMapper>();
            builder.Services.AddTransient<IGeneralInformationMapper, GeneralInformationMapper>();
            builder.Services.AddTransient<IAddressMapper, AddressMapper>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
