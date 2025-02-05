using api.repo.interfaces;
using api.repo.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Samurai>> GetSamurais()
        {

            //context.Samurais.Add(new Samurai { Id = 0, Name = "Karl", Description = "Karl er en samurai" });
            await context.SaveChangesAsync();
            return await context.Samurais.ToListAsync();
            //Samurai samurai = new Samurai();
            //samurai.Name = "Karl";
            //string name = samurai.Name;


            ////herinde skal vi have fat i vores database
            //throw new NotImplementedException();
        }
        public async Task<Samurai> GetSamurai(int id)
        {
            return await context.Samurais.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Samurai> CreateSamurai(Samurai samurai)
        {
            await context.Samurais.AddAsync(samurai);
            await context.SaveChangesAsync();
            return samurai;
        }

        public async Task<Samurai> UpdateSamurai(Samurai samurai)
        {
            context.Samurais.Update(samurai);
            await context.SaveChangesAsync();
            return samurai;
        }

        public async Task<Samurai> DeleteSamurai(int id)
        {
            Samurai samurai = await context.Samurais.FirstOrDefaultAsync(x => x.Id == id);
            context.Samurais.Remove(samurai);
            await context.SaveChangesAsync();
            return samurai;
        }

        public async Task<List<Samurai>> GetSamuraisAndHouse()
        {
            return await context.Samurais.Include((samuraiobj) => samuraiobj.House).ToListAsync();
        }
    }
}
