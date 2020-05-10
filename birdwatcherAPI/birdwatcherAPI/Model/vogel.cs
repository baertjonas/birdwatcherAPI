using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace birdwatcherAPI.Model
{
    public class Vogel
    {
        public Vogel()
        {
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Een naam is verplicht.")]
        public string Naam { get; set; }

        public string Latijns { get; set; }

        public string Frans { get; set; }

        public string Engels { get; set; }

        public string Duits { get; set; }

        [JsonIgnore]
        public ICollection<Waarneming> Waarnemingen { get; set; }

        [ForeignKey("Familie")]
        [Required(ErrorMessage = "Een familieID is verplicht.")]
        public int? FamilieID { get; set; }

        public Familie Familie { get; set; }
    }
}
