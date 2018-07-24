using System;
namespace ManchkinGameApi.Models.Game.Player.Race
{
    public enum RaceEnum
    {
        None = 0,
        Humman=1,
        Dwarf=2,
        Elf=4,
        Halfling=8,
        Cocktail = 16,
        Any = Humman | Dwarf | Elf | Halfling  
    }
}