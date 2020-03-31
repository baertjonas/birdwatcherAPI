using System;
namespace birdwatcherAPI.Model
{
    public enum Halfrond { N, S, W, E }

    static class GeoLocation
    {
        //public GeoLocation(Halfrond Halfrond, int Graden, int Minuten, double Seconden)
        //{
        //    Halfrond = this.Halfrond;
        //    Graden = this.Graden;
        //    Minuten = this.Minuten;
        //    Seconden = this.Seconden;
        //}//

        //public Halfrond Halfrond { get; set; }

        //public int Graden { get; set; }

        //public int Minuten { get; set; }

        //public double Seconden { get; set; }

        public static string GeoToString(string Halfrond, int Graden, int Minuten, double Seconden)
        {
            return $"{Halfrond}{Graden}°{Minuten}'{Seconden}\"";   ////+ "°" + Minuten + "'" + Seconden + "";
        }
    }


}
