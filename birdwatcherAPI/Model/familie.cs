using System;
using System.Collections.Generic;

namespace birdwatcherAPI.Model
{
    public class Familie
    {
        public Familie()
        {
        }

        public int ID { get; set; }

        public string FamilieNaam { get; set; }

        public ICollection<Vogel> Vogels {get; set;}
    }
}
