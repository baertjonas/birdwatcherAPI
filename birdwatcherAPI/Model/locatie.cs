using System;
using System.Collections.Generic;

namespace birdwatcherAPI.Model
{
    public class Locatie
    {
        public Locatie()
        {
        }

        public int ID { get; set; }

        public string Naam { get; set; }

        public string Straat { get; set; }

        public int Nummer { get; set; }

        public int Postcode { get; set; }

        public string Gemeente { get; set; }

        public string GPSbreedte { get; set; }

        public string GPSlengte { get; set; }

        public ICollection<Waarneming> Waarnemingen {get; set;}

    }
}
