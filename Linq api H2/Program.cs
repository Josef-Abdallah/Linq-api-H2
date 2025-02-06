
using api.repo.interfaces;
using api.repo.Models;
using api.repo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Linq_api_H2
{
    /// <summary>
    /// autogenere vores controller
    /// hvis i vil skrive kode er det get og post
    /// databaseops�tning
    /// DI - dependency injection
    /// 
    /// 1) API og DAL ops�tning - packages.....
    /// 2) models i DAL
    /// 3) interfaces i DAL
    /// 4) classes til at h�ndtere data adgang (her er der en del kode)
    /// 
    /// 5) DI skal registreres 
    /// 6) controller skal laves
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<Isamurai, SamuraiRepo>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            string conStr = @"Server=JOSEFS-B�RBAR\SQLEXPRESS;Database=Samurai002; Trusted_Connection=true; Trust Server Certificate=true; Integrated Security=true; Encrypt=True; ";
            //builder.Services.AddDbContext<Database>(options => options.UseSqlServer(conStr));
            builder.Services.AddDbContext<Database>(options =>
        options.UseSqlServer(conStr, b => b.MigrationsAssembly("Linq api H2"))
    );

            //string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


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
