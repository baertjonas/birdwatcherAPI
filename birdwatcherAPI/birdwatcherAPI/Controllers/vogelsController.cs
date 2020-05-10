using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using birdwatcherAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace birdwatcherAPI
{
    [Route("api/[controller]")]
    public class vogelsController : Controller
    {
        private BirdwatcherContext context;

        public vogelsController(BirdwatcherContext context)
        {
            this.context = context;
        }
        // GET api/vogels -> alle vogels
        [HttpGet]
        public IActionResult Get()
        {
            var vogel = context.Vogels;

            if (vogel == null) return NotFound();

            return Ok(vogel);
        }

        // GET api/vogels/ID -> zoek een bepaalde vogel met ID
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var vogel = context.Vogels
                .SingleOrDefault(x => x.ID == id);
            if (vogel == null) return NotFound();

            return Ok(vogel);
        }

        // POST api/vogels
        [HttpPost]
        [AllowAnonymous]
        [Authorize]
        public IActionResult CreateVogel([FromBody] Vogel vogel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Vogels.Add(vogel);
            context.SaveChanges();
            return Created("", vogel);
        }

        // DELETE api/vogels
        [HttpDelete("{id}")]
        [AllowAnonymous]
        [Authorize]
        public IActionResult DeleteVogel(int id)
        {
            

            var vogel = context.Vogels
                .SingleOrDefault(x => x.ID == id);

            if (vogel == null)
                return NotFound();

            context.Vogels.Remove(vogel);
            context.SaveChanges();
            return NoContent();
        }

        // PUT api/vogels
        [HttpPut]
        [AllowAnonymous]
        [Authorize]
        public IActionResult UpdateVogel([FromBody] Vogel vgl)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var orgVogel = context.Vogels.Find(vgl.ID);
            if (orgVogel == null)
                return NotFound();

            orgVogel.Naam = vgl.Naam;
            orgVogel.Latijns = vgl.Latijns;
            orgVogel.Frans = vgl.Frans;
            orgVogel.Engels = vgl.Engels;
            orgVogel.Duits = vgl.Duits;
            orgVogel.FamilieID = vgl.FamilieID;

            context.SaveChanges();
            return Ok(orgVogel);
        }

        [Route("{id}/waarnemingen")]
        // GET api/vogels/ID/waarnemingen -> zoek de waarnemingen van een vogel met ID
        [HttpGet]
        public IActionResult GetWaarnemingen(int id)
        {
            IQueryable<Waarneming> query = context.Waarnemingen;

            query = query.Where(d => d.Vogel.ID == id).Include(d => d.Spotter);

            if (query.ToList().Count() == 0) return NotFound();

            return Ok(query.ToList());
        }

        [Route("{id}/spotters")]
        // GET api/vogels/ID/spotters -> zoek de spotters van een vogel met ID
        [HttpGet]
        public IActionResult GetSpotters(int id)
        {
            IQueryable<Spotter> query = from w in context.Waarnemingen //alle waarnemingen
                                        from s in context.Spotters //alle spotters
                                        where s.ID == w.Spotter.ID //join the tables
                                        where w.Vogel.ID == id //ID moet overeenkomen met ID die meegeven is
                                        select new Spotter
                                        {
                                            ID = s.ID,
                                            Voornaam = s.Voornaam,
                                            Achternaam = s.Achternaam,
                                            Straat = s.Straat,
                                            Nummer = s.Nummer,
                                            Postcode = s.Postcode,
                                            Gemeente = s.Gemeente,
                                            Email = s.Email
                                        };

            if (query.ToList().Count() == 0) return NotFound();

            return Ok(query.ToList());
        }
    }
}