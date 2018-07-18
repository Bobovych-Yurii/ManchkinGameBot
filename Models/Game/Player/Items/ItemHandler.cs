using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game.Cards.Tresure;
namespace ManchkinGameApi.Models.Game.Player.Items
{
    public class ItemHendler
    {
        private readonly PlayerProfile thisPlayerProfile;
        public ItemHendler(PlayerProfile pp)
        {
            thisPlayerProfile = pp;
        }
        protected readonly Dictionary<BodyPartsEnum,BodyPart> ItemContainer = new Dictionary<BodyPartsEnum, BodyPart>()
        {
            {BodyPartsEnum.Head,new BodyPart(BodyPartsEnum.Head)},
            {BodyPartsEnum.Hand,new BodyPart(BodyPartsEnum.Hand,2)},
            {BodyPartsEnum.Chest,new BodyPart(BodyPartsEnum.Chest)},
            {BodyPartsEnum.Foot,new BodyPart(BodyPartsEnum.Foot)},
        };
        public BodyPart getBodyPart(BodyPartsEnum bp){return ItemContainer[bp];}
        public void EquipItem(ItemCard ic)
        {
            ItemContainer[ic.BodyPart].EquipItem(ic);
        }
        public int getDmg()
        {
            var dmg = 0;
            foreach (var item in ItemContainer)
            {
                dmg+= item.Value.getDmg();
            }
            return dmg;
        }
        public List<ItemCard> LostItemList(BodyPartsEnum bp,bool isBig=false,int count=1)
        {
           return ItemContainer[bp].GetLostItem(); //todo diffent item types
        }
        public void TakeOfItem(ItemCard item)
        {
            ItemContainer[item.BodyPart].RemoveItem(item);
        }
    }
}