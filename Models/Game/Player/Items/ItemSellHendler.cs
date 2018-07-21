using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game.Cards.Tresure;
using System.Linq;
using ManchkinGameApi.Models.Commands;
namespace ManchkinGameApi.Models.Game.Player.Items
{
    public class ItemSellHendler
    {
        private readonly PlayerProfile thisPlayerProfile;
        private List<ItemCard> items = new List<ItemCard>();
        private const int MoneyForLvl = 1000;
        public ItemSellHendler(PlayerProfile pp) 
        {
            thisPlayerProfile = pp;
        }
        public void Add(int id)
        {
           var card =  thisPlayerProfile.GetHand().Where(c=>c.Id == id).FirstOrDefault();
           if(card==null) throw new DefautlMesageException("У вас нет такой карты");
           if(!(card.CardType == CardType.Item)) throw new DefautlMesageException("Эту курту нельзя продать");
           items.Add(card as ItemCard);
           thisPlayerProfile.Discard(card);
        }
        public void GetOut(int id)
        {
            var card =  CardsList.GetCard(id);
            if(!items.Contains(card)) throw new DefautlMesageException("Вы не продаете такую карту");
            thisPlayerProfile.TakeCard(card);
            items.Remove(card as ItemCard);
        }
        public string GetMessage()
        {
            var temp = "";
            int price = 0;
            foreach(var item in items)
            {
                temp+=item.Name + " " + item.Price+"\n"
                    +"отмена "+CommandsInfo.UndoSell.Command+"_"+item.Id+"\n";
                price+=item.Price;
            }
            
            temp+="Вы получаете "+price/MoneyForLvl+" уровеней";
            return temp;
        }
        public int SellAll()
        {
            int price = 0;
            foreach(var item in items)
            {
                price+=item.Price;
            }
            var lvlCount = price/MoneyForLvl;
            if(lvlCount >0) items.Clear();
            return  lvlCount;
        }
        public bool IsEmpty(bool useError =false)
        {
            if(useError &&items.Count != 0) throw new DefautlMesageException("Вы не продали вещи");
            return items.Count == 0;
        }
    }
}