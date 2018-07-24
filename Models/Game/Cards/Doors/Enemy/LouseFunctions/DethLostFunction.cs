using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class DethLostFunction
    {
        private Func<PlayerProfile,bool> ExeptFunc;
        private Func<PlayerProfile,bool> OtherwiseAction;
        public DethLostFunction(){}
        public DethLostFunction(Func<PlayerProfile,bool>ExeptFunc=null,Func<PlayerProfile,bool> OtherwiseAction=null)
        {
            this.ExeptFunc = ExeptFunc;
            this.OtherwiseAction = OtherwiseAction;
        }   
        public bool Deth(PlayerProfile pp)
        {
            var done = true;
            if(ExeptFunc == null)
            {
               DeathHelper(pp);
            } else {
                if(ExeptFunc(pp))
                {
                    if(OtherwiseAction == null) DeathHelper(pp);
                } else { 
                   done = OtherwiseAction(pp);
                }
            }
            return done;
        }

        public void DeathHelper(PlayerProfile pp)
        {
            var cards = pp.Death();
            pp.GetPlayerStatistic().IsDead = true;
            //chouse cars for ather players
        }
    }
}