using System;
using System.Collections.Generic;

namespace birdwatcherAPI.Model
{
    public class Spotter
    {
        public Spotter()
        {
        }

        public int ID { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Straat { get; set; }

        public int Nummer { get; set; }

        public int Postcode { get; set; }

        public string Gemeente { get; set; }

        public string Email { get; set; }

        public ICollection<Waarneming> Waarnemingen {get; set;}

    }
}
