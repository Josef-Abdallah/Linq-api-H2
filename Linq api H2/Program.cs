
using api.repo.interfaces;
using api.repo.Models;
using api.repo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Linq_api_H2
{
    /// <summary>
    /// autogenere vores controller
    /// hvis i vil skrive kode er det get og post
    /// databaseopsætning
    /// DI - dependency injection
    /// 
    /// 1) API og DAL opsætning - packages.....
    /// 2) models i DAL
    /// 3) interfaces i DAL
    /// 4) classes til at håndtere data adgang (her er der en del kode)
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
            string conStr = @"Server=THEDWARFS_GAMER\SQLEXPRESS;Database=Samurai002; Trusted_Connection=true; Trust Server Certificate=true; Integrated Security=true; Encrypt=True; ";
            builder.Services.AddDbContext<Database>(options => options.UseSqlServer(conStr));


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
