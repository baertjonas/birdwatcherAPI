using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace birdwatcherAPI.Model
{
    public class Familie
    {
        public Familie()
        {
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Een familie is verplicht.")]
        public string Naam { get; set; }

        [JsonIgnore]
        public ICollection<Vogel> Vogels {get; set;}
    }
}
