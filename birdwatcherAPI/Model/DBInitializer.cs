using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace birdwatcherAPI.Model
{
    public class DBInitializer
    {
        public static void Initialize(BirdwatcherContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //zijn er al families?
            if (!context.Families.Any())
            {
                //create new Waarneming
                var FAM = new Familie()
                {
                    FamilieNaam = "Roofvogel"
            };
            //add Familie to the database
            context.Families.Add(FAM);
            //save changes to the database
            context.SaveChanges();
            }

            //zijn er al vogels?
            if (!context.Vogels.Any())
            {
                //nieuwe vogel
                var VGL1 = new Vogel()
                {
                    Naam = "Wespendief",
                    LatijnseNaam = "Pernis apivorus",
                    Familie = context.Families.Find(1)
                };
                var VGL2 = new Vogel()
                {
                    Naam = "Bruine kiekendief",
                    LatijnseNaam = "Circus aeruginosus",
                    Familie = context.Families.Find(1)
                };
                //vogel toevoegen
                context.Vogels.Add(VGL1);
                context.Vogels.Add(VGL2);
                //save changes to the database
                context.SaveChanges();
            }

            //zijn er al locaties?
            if (!context.Spotters.Any())
            {
                //nieuwe vogel
                var SPO = new Spotter()
                {
                    Voornaam = "Tuur",
                    Achternaam = "Baert",
                    Straat = "Camelialei",
                    Nummer = 13,
                    Postcode = 2170,
                    Gemeente = "Merksem",
                    Email = "tuur.baert@icloud.com"
                };
                //locatie toevoegen
                context.Spotters.Add(SPO);
                //save changes to the database
                context.SaveChanges();
            }

            //zijn er al waarnemingen?
            if (!context.Waarnemingen.Any())
            {
                //nieuwe waarneming
                var WN1 = new Waarneming()
                {
                    Geslacht = Geslacht.Man,
                    DatumTijd = new DateTime(2020, 3, 21, 12, 34, 00),
                    GeoBreedte = GeoLocation.GeoToString("N",51,23,25.528),//"N51°23'25.528\"",
                    GeoLengte = GeoLocation.GeoToString("E", 4, 25, 49.343),
                    Vogel = context.Vogels.Find(1),
                    Spotter = context.Spotters.Find(1)
                };
                var WN2 = new Waarneming()
                {
                    Geslacht = Geslacht.Vrouw,
                    DatumTijd = new DateTime(2020, 2, 28, 17, 31, 00),
                    GeoBreedte = GeoLocation.GeoToString("N", 51,20, 56.038),
                    GeoLengte = GeoLocation.GeoToString("E", 4, 36, 26.202),
                    Vogel = context.Vogels.Find(2),
                    Spotter = context.Spotters.Find(1)
                };
                //waarneming toevoegen
                context.Waarnemingen.Add(WN1);
                context.Waarnemingen.Add(WN2);
                //save changes to the database
                context.SaveChanges();
            }
        }
    }
}
