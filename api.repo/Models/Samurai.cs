using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.repo.Models
{
    /// <summary>
    /// EF (Entity Framework) 
    /// PK (Primary Key) => className + Id (Id, id, ID...) eller id
    /// package manager console: add-migration <name>
    /// </summary>
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int HouseId { get; set; } //foreign key
        public House House { get; set; } //navigation property
    }
}
