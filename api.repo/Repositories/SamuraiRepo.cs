using api.repo.interfaces;
using api.repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.repo.Repositories
{
    /// <summary>
    /// install packages
    /// create models
    /// </summary>
    public class SamuraiRepo : Isamurai
    {
        //hvordan tilgår vi vores database
        //hvad hvis jeg vil generer et objeckt af samurai

        Database context { get; set; }
        public SamuraiRepo(Database c)
        {
            context = c;

        }
        public List<Samurai> GetSamurais()
        {
            //context.Samurais.Add(new Samurai { Name = "Karl", Description = "Karl er en samurai" });

            return context.Samurais.ToList();
            //Samurai samurai = new Samurai();
            //samurai.Name = "Karl";
            //string name = samurai.Name;


            ////herinde skal vi have fat i vores database
            //throw new NotImplementedException();
        }
        public Samurai GetSamurai(int id)
        {
            return context.Samurais.FirstOrDefault(x => x.Id == id);
        }

        public Samurai CreateSamurai(Samurai samurai)
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
            return samurai;
        }
    }
}
