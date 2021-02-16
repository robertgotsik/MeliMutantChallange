using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeliMutantChallange;
using MeliMutantChallange.Models;

namespace MeliMutantChallange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdnsController : ControllerBase
    {
        private readonly MutantContext _context;

        public AdnsController(MutantContext context)
        {
            _context = context;
        }

        // GET: api/Adns
        [HttpGet("stats")]
        public async Task<ActionResult<Stat>> Stats()
        {
            var retval = await _context.Adn.ToListAsync();
            Stat stat = new Stat();
            stat.GetStats(retval);

            return stat;
        }

        // POST: api/Adns
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("mutant")]
        public async Task<ActionResult<Adn>> PostAdn(Adn adn)
        {
            if (Adn.isValid(adn.dna))
            {
                if (!AdnExists(PersistDna(adn)))
                {
                    bool isMutant = Adn.isMutant(adn.dna);

                    if (isMutant)
                    {
                        adn.type = 1;
                        await SaveAdn(adn);
                        return Accepted();
                    }
                    else
                    {
                        adn.type = 0;
                        await SaveAdn(adn);
                        return StatusCode(403);
                    }
                }
                return StatusCode(403);
            }
            else return StatusCode(403);
        }

        private async Task SaveAdn(Adn adn)
        {
            adn.dnaPersisted = String.Join("-", adn.dna);

            _context.Adn.Add(adn);
            await _context.SaveChangesAsync();
        }

        private string PersistDna(Adn adn)
        {
            adn.dnaPersisted = String.Join("-", adn.dna);
            return adn.dnaPersisted;
        }

        private bool AdnExists(string dnaPersisted)
        {
            return _context.Adn.Any(e => e.dnaPersisted == dnaPersisted);
        }
    }
}
