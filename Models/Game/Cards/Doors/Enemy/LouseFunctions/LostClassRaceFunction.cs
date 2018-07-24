using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class LostClassRaceFunction
    {
        private bool lostRace;
        private bool lostClass;
        public LostClassRaceFunction(bool lostClass,bool lostRace)
        {
            this.lostClass = lostClass;
            this.lostRace = lostRace;
        }
        public bool Lost(PlayerProfile pp)
        {
            if(lostClass)
                pp.LostClass();
            if(lostRace)
                pp.LostRace();
            return true;
        }
    }
}