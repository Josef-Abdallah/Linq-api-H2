using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.repo.Models
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }

        public DbSet<Samurai> Samurais { get; set; } //this is a table in the database named Samurais, pk
        public DbSet<House> Houses { get; set; } //this is a table in the database named Houses, pk

        //1) create model
        //2) if there is a relation between models, create a new model (inde i house)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
