using api.repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.repo.interfaces
{
    public interface Isamurai
    {
        // returnerer all samurais
        public Task<List<Samurai>> GetSamurais();
        // returnerer en samurai
        public Task<Samurai> GetSamurai(int id);
        // opretter en samurai
        public Task<Samurai> CreateSamurai(Samurai samurai);
        // opretter en samurai og et hus
        public Task<House> CreateSamuraiAndHouse(House house);
        // opdaterer en samurai
        public Task<Samurai> UpdateSamurai(Samurai samurai);
        // sletter en samurai
        public Task<Samurai> DeleteSamurai(int id);
        // returnerer samurais og hus
        public Task<List<House>> GetHouses();

        public Task<House> DeleteHouse(int id);


    }
}
