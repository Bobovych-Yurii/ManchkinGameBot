using System;
namespace ManchkinGameApi.Models.Game.Cards
{
    public enum CardType
    {
        Tresure = 1,
        Door = 2,
        Enemy = 4 | Door,
        Buff = 8 | Tresure,
        Item = 16 | Tresure,
        Curse = 32 | Door,
        Class = 64 | Tresure,
        LevelUp = 128 | Tresure
    }
}