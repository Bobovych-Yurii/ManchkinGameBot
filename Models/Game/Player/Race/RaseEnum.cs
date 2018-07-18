using System;
namespace ManchkinGameApi.Models.Game.Player.Race
{
    public enum RaceEnum
    {
        Humman=1,
        Dwarf=2,
        Elf=4,
        Halfling=8,
        Any = Humman | Dwarf | Elf | Halfling  
    }
}