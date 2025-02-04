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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
