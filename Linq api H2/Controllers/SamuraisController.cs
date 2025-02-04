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
    public class SamuraisController : ControllerBase
    {
        private readonly Isamurai _context;

        public SamuraisController(Isamurai context)
        {
            _context = context;
        }

        // GET: api/Samurais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurais()
        {
            return await _context.GetSamurais();
        }

        //GET: api/Samurais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samurai>> GetSamurai(int id)
        {
            var samurai = await _context.GetSamurai(id);

            if (samurai == null)
            {
                return NotFound();
            }

            return samurai;
        }

        //// PUT: api/Samurais/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSamurai(int id, Samurai samurai)
        //{
        //    if (id != samurai.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(samurai).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SamuraiExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Samurais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Samurai>> PostSamurai(Samurai samurai)
        {
            return await _context.CreateSamurai(samurai);

            //return CreatedAtAction("GetSamurai", new { id = samurai.Id }, samurai);
        }

        // UPDATE api/Samurais/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Samurai>> PutSamurai(int id, Samurai samurai)
        {
            if (id != samurai.Id)
            {
                return BadRequest();
            }
            var samuraiUpdated = await _context.UpdateSamurai(samurai);
            if (samuraiUpdated == null)
            {
                return NotFound();
            }
            return samuraiUpdated;
        }

        // DELETE: api/Samurais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Samurai>> DeleteSamurai(int id)
        {
            var samurai = await _context.DeleteSamurai(id);

            if (samurai == null)
            {
                return NotFound();
            }

            return samurai;
        }

        //private bool SamuraiExists(int id)
        //{
        //    return _context.Samurais.Any(e => e.Id == id);
        //}
    }
}
