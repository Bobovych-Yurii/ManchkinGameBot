using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Race;

namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public class ItemCard:TresureCard
    {
        public ClassEnum ForClass {get;}
        public RaceEnum ForRace {get;}
        public int Price {get;}
        public BodyPartsEnum BodyPart {get;}
        public int ItemSlots{get;}
        public int DefaultBonus{get;}
        public bool IsBig{get;}
        public ItemCard(string name):base(CardsParamsHendler.GetCard(name) as ItemParams)
        {
            ItemParams cp = CardsParamsHendler.GetCard(name) as ItemParams;
            ForClass = cp.ForClass;
            ForRace = cp.ForRace;
            Price = cp.Price;
            BodyPart = cp.BodyPart;
            ItemSlots = cp.ItemSlots;
            DefaultBonus = cp.DefaultBonus;
            IsBig = cp.IsBig;

        }
        protected override void InPlay(Game game,string playerUserName)
        {
            var pp = game.GetCurrnetPlayer();
            if(isPlayerTurn(pp,playerUserName))
            {
                pp.EquipItem(this);
            }
        }
    } 
}