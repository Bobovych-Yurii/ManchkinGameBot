using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game.Cards.Tresure;
using System.Linq;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Player
{
    public class PlayerProfile
    {
        private Game game{get;}
        public string UserName {get;}
        public long chatId{get; set;}
        public int Level {get;private set;}=1;
        public PlayerState PlayerState{get;set;} = PlayerState.NotReady;
        PlayerGender Gender {get;set;} = PlayerGender.Mele;
        PlayerStatistic Statistics {get;} = new PlayerStatistic();
        ItemHendler Items {get;}
        ClassHendler Class = new ClassHendler();
        RaceHendler Race = new RaceHendler();
        List<Card> PlayerHand {get;} = new List<Card>();
        int maxCardCount = GameParams.MaxCardsInHand;
        public long HandBotChatId{get;set;}
        public PlayerProfile(Game game,string userName)
        {
            this.game = game;
            UserName = userName;
            Items = new ItemHendler(this);
        } 
#region Class
        public PlayerGender GetGender(){
            return Gender;
        }
        public void SetClass(ClassEnum ce,int cardId)
        {
            Class.SetClass(ce,cardId);
            Statistics.IsClassChanged = true;
        }
        public void DropClass(ClassEnum ce,int cardId)
        {
            Class.DropClass(ce,cardId);
            //todo drop card
        }
#endregion
#region Items
    public void EquipItem(ItemCard ic)
        {
            Console.WriteLine(ic.ForRace.ToString("F"));
            if(Class.isClass(ic.ForClass) && Race.isRace(ic.ForRace))
                Items.EquipItem(ic);
            else
                throw new DefautlMesageException("Эта шмотка вам не подходит");

        }
#endregion   
#region Cards
        public List<Card> GetHand()
        {
            return PlayerHand.ToList();
        }
       
        public List<Card> GetEffects(){return null;}

        public List<Card> GetItems(BodyPartsEnum bp)
        {
           
            List<Card> cards = new List<Card>();
            foreach(var card in Items.getBodyPart(bp).getItemsID())
            {
               cards.Add(card as Card);
            }
            return cards;
        }
#endregion
        public int getDmg(){
            var dmg = this.Level;
            dmg += Items.getDmg();
            return dmg;
        }
        
        public PlayerStatistic GetPlayerStatistic(){return Statistics;}
        
        public void LevelUp(){
            if(Level>GameParams.MaxLevel-1) throw new DefautlMesageException("Последний уровент нужно добыть в собственом бою");
            Level+=1;
            Console.WriteLine("levelup");
        }
        public Card TakeCard(Card card){
            this.PlayerHand.Add(card);
            
            return card;
        }
        public IEnumerable<Card> GetClassCards(){
            
            List<Card> cards = new List<Card>();
            foreach(var id in Class.GetClassCardsId())
            {
               cards.Add(CardsList.GetCard(id));
            }
            foreach(var id in Race.GetRaceCardsId())
            {
               cards.Add(CardsList.GetCard(id));
            }
            return cards;
        }
        public void Discard(Card card)
        {
           PlayerHand.Remove(card);
        }
        public bool isClass(ClassEnum ce,bool badEffect = false)
        {
           return Class.isClass(ce,badEffect);
        }
        public bool isRace(RaceEnum re,bool badEffect = false)
        {
            return Race.isRace(re,badEffect);
        }
        public void LostItem(BodyPartsEnum bp,bool isBig=false,int count=1)
        {
            var list = Items.LostItemList(bp,isBig,count);
            
            if(list.Count <= count && list.Count >= 1)
            {                
                HandBotFunctions.SendCards(HandBotChatId,list,"Вы теряете:");
                
                var cardList = new List<Card>();
                foreach (var card in list)
                {
                    game.ToStock(card,this.UserName);
                    GameBotFunctions.ShowUserCard(chatId,card,"@"+UserName+"теряет :");
                }
               
            }
            //todo chouse
        }
    }
}