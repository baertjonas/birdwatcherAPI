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

        //[NS]([0]?[0-8]?[0-9]|9[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}] -> \" werkt niet in .NET
        // -90.000000 => 90.000000
        //[RegularExpression(@"[NS]([0]?[0-8]?[0-9]|9[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}]", ErrorMessage = "Breedtegraad is not valid")]
        public string GeoBreedte { get; set; }

        
        //[WE]([0][0-9][0-9]|1[0-7][0-9]|18[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}]
        // -180.000000 => 180.000000
        //[RegularExpression(@"[WE]([0][0-9][0-9]|1[0-7][0-9]|18[0])[°]\d{1,2}[']\d{0,2}[.]\d{0,3}[\p{Pi}]", ErrorMessage = "Lengtegraad is not valid")]
        public string GeoLengte { get; set; }

        [ForeignKey("Vogel")]
        [Required(ErrorMessage = "VogelID is required")]
        public int? VogelID { get; set; }

        public Vogel Vogel { get; set; }

        [ForeignKey("Spotter")]
        [Required(ErrorMessage = "SpotterID is required")]
        public int? SpotterID { get; set; }

        public Spotter Spotter { get; set; }

    }
}
