using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.repo.Models;
using api.repo.interfaces;

namespace Linq_api_H2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly Isamurai _context;

        public HouseController(Isamurai context)
        {
            _context = context;
        }


        // POST: api/Samurais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostHouse")]
        public async Task<ActionResult<House>> CreateHouse(House house)
        {
            return await _context.CreateSamuraiAndHouse(house);
        }

        // DELETE: api/Samurais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleateHouse(int id)
        {
            return await _context.DeleteHouse(id);
        }



        [HttpGet("withhouse")]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            return await _context.GetHouses();
        }

    }
}
