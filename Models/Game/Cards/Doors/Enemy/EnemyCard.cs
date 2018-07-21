using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;

namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class EnemyCard:DoorCard
    {        
        public int Level;
        public int WinLevelsCount;
        public int WinTresureCount;
        public Func<PlayerProfile,bool> LostFunction;
        public Func<PlayerProfile,int> FightBuff;  
        public Func<PlayerProfile,int> WasOut;
        public List<EnemyBuffCard> baffs = new List<EnemyBuffCard>();
        public EnemyCard(string name):base(CardsParamsHendler.GetCard(name)){
            var ep = CardsParamsHendler.GetCard(name) as EnemyParams;
            this.Level = ep.Level;
            this.WinLevelsCount = ep.WinLevelsCount;
            this.WinTresureCount = ep.WinTresureCount;
            this.LostFunction = ep.LostFunction;
            this.FightBuff = ep.FightBuff;
            this.WasOut = ep.WasOut;
        }

        protected override void InPlay(Game game, string PlayerUserName)
        {
            if(game.GameState == GameState.LookTrable){
               game.PlayEnemy(this);
            }
        }
        public void AddBuff(EnemyBuffCard card)
        {
            baffs.Add(card);
        }
    } 
}