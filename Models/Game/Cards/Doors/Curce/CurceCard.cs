using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;

namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class CurceCard:DoorCard
    {        
        private Action<PlayerProfile> curceFunc;

        //public Func<PlayerProfile,bool> BuffCheck;
        public CurceCard(string name):base(CardsParamsHendler.GetCard(name)){
            var cp = CardsParamsHendler.GetCard(name) as CurceParams;
            curceFunc = cp.curceFunc;
        }

        protected override void InPlay(Game game, string PlayerUserName)
        {
            //game.UseBuffCard(this);
        }
    } 
}