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
        public List<Samurai> GetSamurais();
        // returnerer en samurai
        public Samurai GetSamurai(int id);
        // opretter en samurai
        public Samurai CreateSamurai(Samurai samurai);

    }
}
