using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class ListLostFunction
    {
        private List<Func<PlayerProfile,bool>> lostFuncs;
        public ListLostFunction(List<Func<PlayerProfile,bool>>lostFuncs)
        {
            this.lostFuncs = lostFuncs;
        }
        public bool LostFuncs(PlayerProfile pp)
        {
            var isAllDone = true;
            foreach(var function in lostFuncs){
                if(!function(pp)) isAllDone = false;
            }
            return isAllDone;
        }
    }
}