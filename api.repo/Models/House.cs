using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.repo.Models
{
    //sammurai m  house - database relation (foring key)
    // 1 sammurai har 1 hus - set fra samurai
    // 1 hus har m samurai - set fra hus

    // EF / c# => vender relationen om samurai 1-M house

    public class House
    {
        public int HouseId { get; set; }
        public string adress { get; set; }

        List<Samurai> Samurais { get; set; } = new List<Samurai>(); //dette er vores foring key altså 1

        ////1-1 relation => 1 samurai har 1 house
        //public int HouseId { get; set; } //foring key

        ////1-M relation => 1 house har m samurai
        //public Samurai Samurai { get; set; } //foring key
    }
}
