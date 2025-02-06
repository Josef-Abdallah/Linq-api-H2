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

        //gemme et hus
        //create en nyt hus ved at house h = samurai.house
        //gemme i db
        //constant.house.find den vi får ud af det skal lægges ind i samurai 
        public async Task<House> CreateSamuraiAndHouse(House house)
        {
            await context.Houses.AddAsync(house);
            await context.SaveChangesAsync();
            return house;
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

        public async Task<List<House>> GetHouses()
        {
            return await context.Houses.ToListAsync();
        }

        public async Task<House> DeleteHouse(int id)
        {
            House house = await context.Houses.FirstOrDefaultAsync(x => x.HouseId == id);
            context.Houses.Remove(house);
            await context.SaveChangesAsync();
            return house;
        }
    }
}
