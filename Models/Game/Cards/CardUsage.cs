using System;
namespace ManchkinGameApi.Models.Game.Cards
{
    public enum CardUsage
    {
        Self = 1,
        Player = 2,
        Enemy= 4,
        Stock= 8,
        
    }
}