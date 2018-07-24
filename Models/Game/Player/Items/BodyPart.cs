using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game.Cards.Tresure;
using System.Linq;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Player.Items
{
    public class BodyPart
    {
        public readonly BodyPartsEnum PartName;
        public int maxItemCount{get;private set;} // -1 for any ammount
        List<ItemCard> items = new List<ItemCard>();
        public  BodyPart(BodyPartsEnum partName,int maxItemCount=1)
        {
            PartName = partName;
            this.maxItemCount = maxItemCount;
        }
        public void EquipItem(ItemCard ic)
        {
            if(ic.ItemSlots+items.Count > maxItemCount) throw new DefautlMesageException("вы не можете надеть эту екипировку\nСнимите какую-то вещь");
            items.Add(ic);
            
        }
        public void RemoveItem(ItemCard ic)
        {
           if(items.Remove(ic) == false) throw new DefautlMesageException("У вас нет такой карты"); 
        }
        public List<ItemCard> getItems(){
            return items;
        }
        public int getDmg()
        {
            int dmg = 0;
            foreach (var item in items)
            {
                dmg+=item.DefaultBonus;
            }
            return dmg;
        }
        public List<ItemCard> GetItems(bool isbig)
        {
            var lostItems = new List<ItemCard>();
            foreach (var item in items)
            {
                if(item.IsBig == isbig) lostItems.Add(item);
            }
            return lostItems;
        }
        public List<ItemCard> GetItems()
        {
            var lostItems = new List<ItemCard>();
            foreach (var item in items)
            {
                lostItems.Add(item);
            }
            return lostItems;
        }
    }
}