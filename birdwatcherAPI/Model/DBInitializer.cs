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

            //zijn er al Families?
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
            if (!context.Locaties.Any())
            {
                //nieuwe vogel
                var LOC = new Locatie()
                {
                    Naam = "De Zegge",
                    Straat = "Mosselgoren",
                    Nummer = 3,
                    Postcode = 2440,
                    Gemeente = "Geel",
                    GPSbreedte = "51°12'04.1\"N",
                    GPSlengte = "4°56'42.1\"E"
                };
                //locatie toevoegen
                context.Locaties.Add(LOC);
                //save changes to the database
                context.SaveChanges();
            }

            //are there already Waarnemingen present?
            if (!context.Waarnemingen.Any())
            {
                //create new Waarneming
                var WN1 = new Waarneming()
                {
                    Geslacht = Geslacht.Man,
                    DatumTijd = new DateTime(2020, 3, 21, 12, 34, 00),
                    Vogel = context.Vogels.Find(1),
                    Locatie = context.Locaties.Find(1)
                };
                var WN2 = new Waarneming()
                {
                    Geslacht = Geslacht.Vrouw,
                    DatumTijd = new DateTime(2020, 2, 28, 17, 31, 00),
                    Vogel = context.Vogels.Find(2),
                    Locatie = context.Locaties.Find(1)

                };
                //add Waarneming to the database
                context.Waarnemingen.Add(WN1);
                context.Waarnemingen.Add(WN2);
                //save changes to the database
                context.SaveChanges();
            }
        }
    }
}
