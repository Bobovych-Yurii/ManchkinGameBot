using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;

namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class EnemyBuffCard:DoorCard
    {        
        public int Buff;
        public int WinLevelsCount;
        public int WinTresureCount;
        //public Func<PlayerProfile,bool> BuffCheck;
        public EnemyBuffCard(string name):base(CardsParamsHendler.GetCard(name)){
            var ebp = CardsParamsHendler.GetCard(name) as EnemyBuffParams;
            this.Buff = ebp.Buff;
            this.WinLevelsCount = ebp.WinLevelsCount;
            this.WinTresureCount = ebp.WinTresureCount;
           // this.BuffCheck = ebp.BuffCheck;
        }

        protected override void InPlay(Game game, string PlayerUserName)
        {
            //if(BuffCheck(game.GetCurrnetPlayer()))
            {
                game.UseBuffCard(this);
            }
        }
    } 
}