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

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string Achternaam { get; set; }

        public string Straat { get; set; }

        public int Nummer { get; set; }

        public int Postcode { get; set; }

        public string Gemeente { get; set; }

        [EmailAddress(ErrorMessage = "Email is niet in het geldige formaat.")]
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<Waarneming> Waarnemingen {get; set;}

    }
}
