using System;
namespace ManchkinGameApi.Models.Game.Player.Class
{
    public enum ClassEnum
    {
        None=1,
        Thief=2,
        Warior=4,
        Wizard=8,
        Clirick=16,
        Super=32,
        Any = Thief | Warior | Wizard | Clirick | None 
    }
}