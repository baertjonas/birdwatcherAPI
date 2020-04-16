using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace birdwatcherAPI.Model
{
    public class Spotter
    {
        public Spotter()
        {
        }

        public int ID { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Achternaam { get; set; }

        public string Straat { get; set; }

        public int Nummer { get; set; }

        public int Postcode { get; set; }

        public string Gemeente { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<Waarneming> Waarnemingen {get; set;}

    }
}
