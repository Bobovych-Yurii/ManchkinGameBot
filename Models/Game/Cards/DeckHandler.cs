using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Models.Game.Cards.Tresure;
using System.Linq;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Cards
{
    public class DeckHendler
    {
        List<TresureCard> TresureDeck = new List<TresureCard>();
        List<DoorCard> DoorDeck = new List<DoorCard>();
        List<TresureCard> TresureStock = new List<TresureCard>();
        List<DoorCard> DoorStock = new List<DoorCard>();
        public  DeckHendler()
        {
            foreach(Card card in CardsList.GetCards())
            {
                if((card.CardType&CardType.Tresure)!= 0) TresureDeck.Add(card as TresureCard);
                if((card.CardType&CardType.Door)!= 0) DoorDeck.Add(card as DoorCard);

                
            
                //todo mix cards
            }
        }
        public TresureCard GetTresureCard()
        {
            //todo get card From stock
            
            TresureCard tc = TresureDeck[0];
            
            return tc;
        }
        public void TresureCardResived(TresureCard tc)
        {
            TresureDeck.Remove(tc);
        }
        public void DoorCardResived(DoorCard dc)
        {
            DoorDeck.Remove(dc);
        }
        public DoorCard GetDoorCard()
        {
            DoorCard dc = DoorDeck[0];
            DoorDeck.Remove(dc);
            return dc;
        }
        public void ToStock(Card card)
        {
            if(card is TresureCard)
                TresureStock.Add(card as TresureCard);
            if(card is DoorCard){}
                DoorStock.Add(card as DoorCard);

        }
        public TresureCard FromStock(TresureCard tc)
        {
            var temp = TresureStock.LastOrDefault();
            if(temp == null) throw new DefautlMesageException("В стоке нет карт");
            return temp;
        }

    }
}