using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace birdwatcherAPI.Model
{
    public enum Geslacht { Man, Vrouw }

    public class Waarneming
    {
        public Waarneming()
        {
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "DatumTijd is required")]
        public DateTime? DatumTijd { get; set; }

        public Geslacht Geslacht { get; set; }

        // DMS: N41°24'12.2" 
        //[NS]([0]?[0-8]?[0-9]|9[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}] -> \" werkt niet in .NET
        //[RegularExpression(@"[NS]([0]?[0-8]?[0-9]|9[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}]", ErrorMessage = "Breedtegraad is not valid")]
        // in .NET is het niet mogelijk om " als karakter mee te geven, ook niet met \" -> daarom gebruik maken van DD
        // DD: -90.000000° <-> 90.000000°
        [Range(-90.00, 90.00, ErrorMessage = "De de breedtegraad moet tussen -90° en 90° liggen.")]
        public double GeoBreedte { get; set; }

        // DMS: W41°24'12.2" 
        //[WE]([0][0-9][0-9]|1[0-7][0-9]|18[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}] -> \" werkt niet in .NET
        //[RegularExpression(@"[WE]([0][0-9][0-9]|1[0-7][0-9]|18[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}]", ErrorMessage = "Lengtegraad is not valid")]
        // in .NET is het niet mogelijk om " als karakter mee te geven, ook niet met \" -> daarom gebruik maken van DD
        // DD: -180.000000° <-> 180.000000°
        [Range(-180.00,180.00, ErrorMessage = "De lengtegraad moet tussen -180° en 180° liggen.")]
        public double GeoLengte { get; set; }

        [ForeignKey("Vogel")]
        [Required(ErrorMessage = "Een vogelID is verplicht.")]
        public int? VogelID { get; set; }

        public Vogel Vogel { get; set; }

        [ForeignKey("Spotter")]
        [Required(ErrorMessage = "Een spotterID is verplicht.")]
        public int? SpotterID { get; set; }

        public Spotter Spotter { get; set; }

    }
}
