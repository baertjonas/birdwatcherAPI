using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using birdwatcherAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace birdwatcherAPI.Controllers
{
    [Route("api/[controller]")]
    public class waarnemingenController : Controller
    {
        private BirdwatcherContext context;

        public waarnemingenController(BirdwatcherContext context)
        {
            this.context = context;
        }

        // GET: api/waarnemingen -> alle waarnemingen
        [Authorize]
        [HttpGet]
        public IActionResult GetWaarneming(string VogelNaam, string SpotterVoornaam, string SpotterAchternaam, int? page, string sort, int length = 10, string dir = "asc")
        {
            IQueryable<Waarneming> query = context.Waarnemingen;

            if (!string.IsNullOrWhiteSpace(VogelNaam))
                query = query.Where(x => x.Vogel.Naam.Contains(VogelNaam));
            if (!string.IsNullOrWhiteSpace(SpotterVoornaam))
                query = query.Where(x => x.Spotter.Voornaam.Contains(SpotterVoornaam));
            if (!string.IsNullOrWhiteSpace(SpotterAchternaam))
                query = query.Where(x => x.Spotter.Achternaam.Contains(SpotterAchternaam));

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "VogelNaam":
                        if (dir == "asc") {
                            query = query.OrderBy(d => d.Vogel.Naam);
                        } else if (dir == "desc") {
                            query = query.OrderByDescending(d => d.Vogel.Naam);
                        }
                        break;
                    case "SpotterAchternaam":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.Spotter.Achternaam);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.Spotter.Achternaam);
                        }
                        break;
                    case "SpotterVoornaam":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.Spotter.Voornaam);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.Spotter.Voornaam);
                        }
                        break;
                    case "DatumTijd":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.DatumTijd);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.DatumTijd);
                        }
                        break;
                }
            }

            if (page.HasValue)
            {
                query = query.Skip(page.Value * length);
            }
            query = query.Take(length);

            query = query.Include(x => x.Vogel).Include(x => x.Spotter).Include(x => x.Vogel.Familie);

            // if (query.ToList().Count() == 0) return NotFound("De query leverde geen resultaten.");
            // => QUERY MAG EEN LEGE LIJST TERUGGEVEN => WORDT OPGEVANGEN IN CLIENT

            return Ok(query);
        }   
        
        // GET api/waarnemingen/ID -> zoek een bepaalde waarneming met ID
        [HttpGet("{id}")]
        public IActionResult GetWaarnemingByID(int id)
        {
            var waarneming = context.Waarnemingen
                .Include(x => x.Vogel)
                .Include(x => x.Spotter)
                .SingleOrDefault(x => x.ID == id);

            if (waarneming == null) return NotFound();

            return Ok(waarneming);
        }

        // POST api/waarnemingen
        [HttpPost]
        public IActionResult CreateWaarneming([FromBody] Waarneming waarneming)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //TODO modelstate meegeven

            // check of de vogel al bestaat in de database
            var vogel = context.Vogels
                .SingleOrDefault(x => x.ID == waarneming.VogelID);
            if (vogel == null) return NotFound("Vogel bestaat nog niet in de database");
            // check of de spotter al bestaat in de database
            var spotter = context.Spotters
                .SingleOrDefault(x => x.ID == waarneming.SpotterID);
            if (spotter == null) return NotFound("Spotter bestaat nog niet in de database");

            //waarneming.SpotterID = waarneming.SpotterID; //add a foreign key
            //waarneming.VogelID = waarneming.Vogel.ID; //add a foreign key

            //waarneming.Vogel = null; // er mogen geen nieuwe vogels worden toegevoegd...
            //waarneming.Spotter = null; // er mogen geen nieuwe spotters worden toegevoegd...

            context.Waarnemingen.Add(waarneming);
           
            context.SaveChanges();
            return Created("", waarneming);
        }

        // DELETE api/waarnemingen/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWaarneming (int id)
        {
            var waarneming = context.Waarnemingen
                .SingleOrDefault(x => x.ID == id);
            if (waarneming == null)
                return NotFound();

            context.Waarnemingen.Remove(waarneming);
            context.SaveChanges();
            return NoContent();
        }

        // PUT api/waarmeningen/{id}
        [HttpPut]
        public IActionResult UpdateWaarneming([FromBody] Waarneming waarneming)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var orgWaarneming = context.Waarnemingen.Find(waarneming.ID);

            if (orgWaarneming == null)
                return NotFound();

            // check of de vogel al bestaat in de database
            var vogel = context.Vogels
                .SingleOrDefault(x => x.ID == waarneming.VogelID);
            if (vogel == null) return NotFound("Vogel bestaat nog niet in de database");
            // check of de spotter al bestaat in de database
            var spotter = context.Spotters
                .SingleOrDefault(x => x.ID == waarneming.SpotterID);
            if (spotter == null) return NotFound("Spotter bestaat nog niet in de database");

            orgWaarneming.DatumTijd = waarneming.DatumTijd;
            orgWaarneming.Geslacht = waarneming.Geslacht;
            orgWaarneming.GeoBreedte = waarneming.GeoBreedte;
            orgWaarneming.GeoLengte = waarneming.GeoLengte;
            //orgWaarneming.Spotter = null; //werken met foreign key ipv objecten
            orgWaarneming.SpotterID = waarneming.SpotterID;
            //orgWaarneming.Vogel = null; //werken met foreign key ipv objecten
            orgWaarneming.VogelID = waarneming.VogelID;
            
            context.SaveChanges();
            return Ok(orgWaarneming);
        }

        [Route("{id}/spotters")]
        // GET api/waarnemingen/ID/spotters -> laat de spotter zien van waarneming met id
        [HttpGet]
        public IActionResult GetSpotters(int id)
        {
            IQueryable<Spotter> query = from s in context.Spotters
                                        from w in context.Waarnemingen
                                        where s.ID == w.SpotterID
                                        where w.ID == id
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

        [Route("{id}/vogels")]
        // GET api/waarnemingen/ID/vogels -> laat de vogel zien van waarneming met id
        [HttpGet]
        public IActionResult GetVogels(int id)
        {
            IQueryable<Vogel> query = from v in context.Vogels
                                      from w in context.Waarnemingen
                                      where v.ID == w.VogelID
                                      where w.ID == id
                                      select new Vogel
                                      {
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
