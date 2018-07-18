using System;
namespace ManchkinGameApi.Models.Game
{
    public static class Dise
    {
        private static Random rand = new Random();
        public static int Roll(){return rand.Next(1,6);}
    }
}