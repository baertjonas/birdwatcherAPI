using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace birdwatcherAPI.Model
{
    public class Vogel
    {
        public Vogel()
        {
        }

        public int ID { get; set; }

        [Required]
        public string Naam { get; set; }

        public string Latijns { get; set; }

        public string Frans { get; set; }

        public string Engels { get; set; }

        public string Duits { get; set; }

        [JsonIgnore]
        public ICollection<Waarneming> Waarnemingen { get; set; }

        //public Familie Familie { get; set; }
    }
}
