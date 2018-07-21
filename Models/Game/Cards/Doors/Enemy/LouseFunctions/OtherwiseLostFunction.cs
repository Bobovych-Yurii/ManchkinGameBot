using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class OtherwiseLostFunction
    {
        private Func<PlayerProfile,bool> FirstFuncs;
        private Func<PlayerProfile,bool> SecondFuncs;
        private Func<PlayerProfile,bool> IsFirstFuncs;
        public OtherwiseLostFunction(Func<PlayerProfile,bool> FirstFuncs,Func<PlayerProfile,bool> SecondFuncs,Func<PlayerProfile,bool> IsFirstFuncs){
            this.FirstFuncs = FirstFuncs;
            this.SecondFuncs = SecondFuncs;
            this.IsFirstFuncs = IsFirstFuncs;
        }
           
        public bool Lost(PlayerProfile pp)
        {
            if(IsFirstFuncs(pp))
                return FirstFuncs(pp);
            else
                return SecondFuncs(pp);
        }
        
    }
}