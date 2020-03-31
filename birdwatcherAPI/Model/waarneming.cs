using System;

namespace birdwatcherAPI.Model
{
    public enum Geslacht { Man, Vrouw }

    public class Waarneming
    {
        public Waarneming()
        {
        }

        public int ID { get; set; }

        public DateTime DatumTijd { get; set; }

        public Geslacht Geslacht { get; set; }

        public string GeoBreedte { get; set; }

        public string GeoLengte { get; set; }

        public Vogel Vogel { get; set; }

        public Spotter Spotter { get; set; }

    }
}
