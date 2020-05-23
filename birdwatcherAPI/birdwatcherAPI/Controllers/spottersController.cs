using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using birdwatcherAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace birdwatcherAPI.Controllers
{ 
    [Route("api/[controller]")]
    public class spottersController : Controller
    {
        private BirdwatcherContext context;

        public spottersController(BirdwatcherContext context)
        {
            this.context = context;
        }
        // GET api/spotter -> alle spotter
        [HttpGet]
        public IActionResult Get()
        {
            var spotter = context.Spotters;

            if (spotter == null) return NotFound();

            return Ok(spotter);
        }

        // GET api/spotter/ID -> zoek een bepaalde spotter met ID
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var spotter = context.Spotters
                .SingleOrDefault(x => x.ID == id);
            if (spotter == null) return NotFound();

            return Ok(spotter);
        }

        // POST api/spotters
        [HttpPost]
        public IActionResult CreateSpotter([FromBody] Spotter spotter)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Spotters.Add(spotter);
            context.SaveChanges();
            return Created("", spotter);
        }

        // DELETE api/spotters/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSpotter(int id)
        {
            var spotter = context.Spotters
                .SingleOrDefault(x => x.ID == id);
            if (spotter == null) return NotFound();

            context.Spotters.Remove(spotter);
            context.SaveChanges();
            return NoContent();
        }

        // PUT api/spotters
        [HttpPut]
        public IActionResult UpdateSpotter([FromBody] Spotter spotter)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var orgSpotter = context.Spotters.Find(spotter.ID);
            if (orgSpotter == null)
                return NotFound();

            orgSpotter.Voornaam = spotter.Voornaam;
            orgSpotter.Achternaam = spotter.Achternaam;
            orgSpotter.Straat = spotter.Straat;
            orgSpotter.Nummer = spotter.Nummer;
            orgSpotter.Postcode = spotter.Postcode;
            orgSpotter.Gemeente = spotter.Gemeente;
            orgSpotter.Email = spotter.Email;
            
            context.SaveChanges();
            return Ok(orgSpotter);
        }

        [Route("{id}/waarnemingen")]
        // GET api/spotters/ID/waarnemingen -> zoek alle waarnemingen van een spotters met ID
        [HttpGet]
        public IActionResult GetWaarnemingen(int id)
        {
            IQueryable<Waarneming> query = context.Waarnemingen;

            query = query.Where(d => d.Spotter.ID == id).Include(d => d.Vogel);

            if (query.ToList().Count() == 0) return NotFound(); 

            return Ok(query.ToList());
        }

        [Route("{id}/vogels")]
        // GET api/spotters/ID/vogels -> zoek de vogels van die een spotter met ID heeft waargenomen
        [HttpGet]
        public IActionResult GetVogels(int id)
        {
            IQueryable<Vogel> query = from w in context.Waarnemingen
                                      from v in context.Vogels
                                      where v.ID == w.Vogel.ID
                                      where w.Spotter.ID == id
                                      select new Vogel {
                                          ID = v.ID,
                                          Naam = v.Naam,
                                          Latijns = v.Latijns,
                                          Frans = v.Frans,
                                          Engels = v.Engels,
                                          Duits = v.Duits
                                      };

            if (query.ToList().Count() == 0) return NotFound();

            return Ok(query.ToList());
        }
    }
}
 