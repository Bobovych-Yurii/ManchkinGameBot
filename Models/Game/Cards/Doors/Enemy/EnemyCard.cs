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
        public Action<PlayerProfile> LostFunction;
        public Func<PlayerProfile,int> FightBuff;  
        public List<BuffCard> baffs = new List<BuffCard>();
        public EnemyCard(string name):base(CardsParamsHendler.GetCard(name)){
            var ep = CardsParamsHendler.GetCard(name) as EnemyParams;
            this.Level = ep.Level;
            this.WinLevelsCount = ep.WinLevelsCount;
            this.WinTresureCount = ep.WinTresureCount;
            this.LostFunction = ep.LostFunction;
            this.FightBuff = ep.FightBuff;
        }

        protected override void InPlay(Game game, string PlayerUserName)
        {
            //todo play with walkig bist
        }
        public void AddBuff(BuffCard card)
        {
            baffs.Add(card);
        }
    } 
}