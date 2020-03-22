using System;
using System.Collections.Generic;

namespace birdwatcherAPI.Model
{
    public class Vogel
    {
        public Vogel()
        {
        }

        public int ID { get; set; }

        public string Naam { get; set; }

        public string LatijnseNaam { get; set; }

        public ICollection<Waarneming> Waarnemingen { get; set; }

        public Familie Familie { get; set; }
    }
}
