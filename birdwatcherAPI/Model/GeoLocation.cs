using System;
namespace birdwatcherAPI.Model
{
    public enum Halfrond { N, S, W, E }

    static class GeoLocation
    {
        public static string GeoToString(string Halfrond, int Graden, int Minuten, double Seconden)
        {
            return $"{Halfrond}{Graden}°{Minuten}'{Seconden}\"";   ////+ "°" + Minuten + "'" + Seconden + "";
        }
    }
}