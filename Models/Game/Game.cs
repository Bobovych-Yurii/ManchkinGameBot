using System;
using System.Collections;
using System.Collections.Generic;
using Telegram.Bot;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Functions;
using System.Linq;
using ManchkinGameApi.Models.Game.Cards.Tresure;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Models.Game.Fight;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;

namespace ManchkinGameApi.Models.Game
{
    public class Game
    {
        public long GameId {get;private set;}
        private readonly List<PlayerProfile> players = new List<PlayerProfile>();
        public RollHendler RollHendler;
        public long ChatId {get;private set;}
        public GameState GameState = GameState.Preparation;
        public Chouse Chouse = new Chouse();
        private DeckHendler deckHendler = new DeckHendler();
        private PlayerTurnQueue turnQueur = new PlayerTurnQueue();
        private FightHendler fightHendler;
        private WashOutHandler washOutHandler;
        private int PlayersReady = 0;
        public Game(long chatId,long gameId)
        {
            ChatId = chatId;
            GameId = gameId;
        }
        public void AddUser(string userName,int place=-1)
        {
            PlayerProfile newPlayer = new PlayerProfile(this,userName);
            if(!players.Contains(newPlayer)){
                players.Add(newPlayer);   
                turnQueur.Add(newPlayer);
            } else {
                throw new DefautlMesageException("вы уже заняли место в игре ");
            }
        }
        public void GetStartHand(PlayerProfile pp)
        {
            for(int i=0; i < GameParams.StartCardsCount/2;i++){
                    
                    Card resived = pp.TakeCard(deckHendler.GetTresureCard());
                    if(resived is TresureCard) deckHendler.TresureCardResived(resived as TresureCard);

                    resived = pp.TakeCard(deckHendler.GetDoorCard());
                    if(resived is DoorCard) deckHendler.DoorCardResived(resived as DoorCard);
                }
        }
        public void SetHandBot(long playerChatId,string playerName)
        {
            var tempPp = players.Where(pp =>pp.UserName == playerName).First();
            if(!tempPp.GetPlayerStatistic().IsStartCardsTaken)
            {
                tempPp.HandBotChatId = playerChatId;
                GetStartHand(tempPp);
            
                HandBotFunctions.SendHand(playerChatId,tempPp.GetHand());
                tempPp.GetPlayerStatistic().IsStartCardsTaken = true;
                tempPp.PlayerState = PlayerState.Iddle;
            }else{
                HandBotFunctions.SendMessage(playerChatId,"вы авторизовались");
            }
            PlayersReady++;
            if(PlayersReady == players.Count)
            {
                turnQueur.Current().PlayerState = PlayerState.OwnTurn;
                turnQueur.Current().SellHendler = new ItemSellHendler(turnQueur.Current());
                HandBotFunctions.SendKeyboadrd(turnQueur.Current().HandBotChatId,GameState,PlayerState.OwnTurn);
            }
            
        }
        public long GetHandBotId(string playerName)
        {
            return players.Where(pp =>pp.UserName == playerName).First().chatId;
        }
        public long StartGame()
        { 
            GameState = GameState.StartTurn;
            return GameId;
        }
        public void SartTurn()
        {
            
            GameState = GameState.StartTurn;
            var current = turnQueur.Next();
            
            if(current.GetPlayerStatistic().IsDead == true)
            {
                GetStartHand(current);
                current.GetPlayerStatistic().IsDead = false;
            }
            current.PlayerState = PlayerState.OwnTurn;
            GameBotFunctions.SendMessage(ChatId,"Начинаеться ход @"+current.UserName);
            HandBotFunctions.SendMessage(current.HandBotChatId,"Твой ход");
            HandBotFunctions.SendKeyboadrd(current.HandBotChatId,GameState,current.PlayerState);
            current.SellHendler = new ItemSellHendler(current);
        }

        public PlayerProfile GetCurrnetPlayer()
        {
            return turnQueur.Current();
        }
        public PlayerProfile GetProfile(string userName){
            return players.Where(p=>p.UserName == userName).First();
        }
        public Dictionary<string,int> GetPlayersLevel(){
            var playersLevel = new Dictionary<string,int>();
            foreach(var pp in players){
                playersLevel.Add(pp.UserName,pp.Level);
            }
            return playersLevel;
        }
        public void Discard(Card card,string playerName,bool toStock = false){
            if(toStock)
                deckHendler.ToStock(card);
            players.Where(p=>p.UserName == playerName).First().Discard(card);
        }
        public void ToStock(Card card){
            deckHendler.ToStock(card);
        }

        public DoorCard GetDoorCard()
        {
            return deckHendler.GetDoorCard();
        }
        public void PlayEnemy(EnemyCard card)
        {
                GameState = GameState.Fight;
                turnQueur.Current().SellHendler = null;
                var minorPlayers = new List<PlayerProfile>();
                foreach (var player in players)
                {
                    if(player.UserName != turnQueur.Current().UserName)
                    {
                        minorPlayers.Add(player);
                    }
                }
                fightHendler = new FightHendler(this,turnQueur.Current(),minorPlayers);
                fightHendler.SetMonster(card as EnemyCard);
                GetCurrnetPlayer().PlayerState = PlayerState.Fight;
                var temp = "@"+turnQueur.Current().UserName+" вступает в бой с:";
                GameBotFunctions.ShowUserCard(ChatId,card,temp);
                HandBotFunctions.SendCards(turnQueur.Current().HandBotChatId,new List<Card>(){card},"Вы стажаетесь с","card",
                    HandBotFunctions.GetMainPlayerKeyboard(GameState,turnQueur.Current().PlayerState));
        }
        public void KickDoor()
        {
            turnQueur.Current().SellHendler.IsEmpty(true);

            GameState = GameState.KickDoor;
            turnQueur.Current().PlayerState = PlayerState.Fight;
            var card = deckHendler.GetDoorCard();
            //todo otherecard type
            
            if(card.CardType == CardType.Enemy)
            {
                PlayEnemy(card as EnemyCard);
                
            } else if(card.CardType == CardType.Curse){
                //play curse

                GameState = GameState.LookTrable;
                turnQueur.Current().PlayerState = PlayerState.LookTrable;
                var temp = "@"+turnQueur.Current().UserName+" проклят"; 
                GameBotFunctions.ShowUserCard(ChatId,card,temp);
                HandBotFunctions.SendCards(turnQueur.Current().HandBotChatId,new List<Card>(){card},"ты получаешь карту","card",
                    HandBotFunctions.GetMainPlayerKeyboard(GameState,turnQueur.Current().PlayerState));
            } else {
                turnQueur.Current().TakeCard(card);
               
                GameState = GameState.LookTrable;
                turnQueur.Current().PlayerState = PlayerState.LookTrable;
                var temp = "@"+turnQueur.Current().UserName+" получат карту";
                GameBotFunctions.ShowUserCard(ChatId,card,temp);
                HandBotFunctions.SendCards(turnQueur.Current().HandBotChatId,new List<Card>(){card},"ты получаешь карту","card",
                    HandBotFunctions.GetMainPlayerKeyboard(GameState,turnQueur.Current().PlayerState));
            }
        }
        public void FinishFight(){
            if(fightHendler == null) throw new DefautlMesageException("Сейчас не идет бой");

            var result = fightHendler.Finish();
            Console.WriteLine(result+"win fight");
            if(result)
            { // win
            fightHendler.Win();
            GameState = GameState.Charity;
            turnQueur.Current().PlayerState = PlayerState.Charity;
            turnQueur.Current().SellHendler = new ItemSellHendler(turnQueur.Current());
            GameBotFunctions.SendMessage(ChatId,"Бой закончен");

            } else {//lost
                fightHendler.Lost();
                
            }
            fightHendler = null;
            //todo wim lost
        }
        public void CountFight(long chatId){
            if(fightHendler == null) throw new DefautlMesageException("Сейчас не идет бой");
            
            HandBotFunctions.SendMessage(chatId,fightHendler.Count());
        }
        public List<PlayerProfile> PlayersList()
        {
            return players;
        }
        public List<PlayerProfile> PlayersList(string userName)
        {
            List<PlayerProfile> pps = new List<PlayerProfile>();
            foreach (var player in players)
            {
                if(player.UserName != userName)
                {
                    pps.Add(player);
                }
            }
            return pps;
        }
        public bool UseBuffCard(EnemyBuffCard card)
        {   
            if(fightHendler == null || GameState != GameState.Fight) throw new DefautlMesageException("Сейчас не идет бой");
            fightHendler.UseBuff(card);
            return false;
        }
        public void PlayerTakeCard(PlayerProfile pp,CardType ct,bool openTake)
        {
            switch(ct)
            {
                case CardType.Tresure:
                    var resived = pp.TakeCard(deckHendler.GetTresureCard());            
                    if(resived as TresureCard != null)
                    {
                        deckHendler.TresureCardResived(resived as TresureCard);
                        HandBotFunctions.SendCards(pp.HandBotChatId,new List<Card>{resived},"Берете карту");
                        if(openTake) 
                        {
                            GameBotFunctions.ShowUserCard(ChatId,resived,"@"+pp.UserName+" получает карту");
                        }
                    }
                    break;
                default: throw new DefautlMesageException("wtf 1");
            }
            
            
        }
        public void StartWashOut(List<PlayerProfile> lostPlayers,List<EnemyCard> enemy)
        {
            GameState = GameState.WashOut;
            washOutHandler = new WashOutHandler(this,lostPlayers,enemy);
            foreach (var pp in lostPlayers)
            {
                pp.PlayerState = PlayerState.WashOut;
                var temp = "Приготовтесь к смывке\n"+washOutHandler.GetMessage();
                HandBotFunctions.SendMessage(pp.HandBotChatId,temp);
                HandBotFunctions.SendKeyboadrd(pp.HandBotChatId,GameState,pp.PlayerState);
            }   
        }
        public void FinishWashOut(PlayerProfile pp,bool fromLostFunc=false)
        {
            var finish = washOutHandler.Finish(pp,fromLostFunc);
            Console.WriteLine(finish +"must be true");
            if(finish)
            {
                pp.SellHendler = new ItemSellHendler(pp);
                GameState = GameState.Charity; 
                HandBotFunctions.SendMessage(GetCurrnetPlayer().HandBotChatId,"Можешь сыграть свои карты");
                GameBotFunctions.SendMessage(ChatId,"Бой закончен");
                HandBotFunctions.SendKeyboadrd(pp.HandBotChatId,GameState,pp.PlayerState);
            }
        }
        
        public void FinishCharity(PlayerProfile pp)
        {
            pp.SellHendler.IsEmpty();
            
            var maxCard = GameParams.MaxCardsInHand;
            if(pp.isClass(ClassEnum.Warior)) maxCard+=1;
            if(pp.GetHand().Count <= maxCard)
            {
                
                HandBotFunctions.SendMessage(pp.HandBotChatId,"Твой ход закончен");
                pp.PlayerState = PlayerState.Iddle;
                var finish = true;
                foreach(var player in players)
                {
                    if(player.PlayerState == PlayerState.Charity)
                    {
                      finish = false;  
                    }
                }
                if(finish)
                {
                    SartTurn();
                } else {
                    HandBotFunctions.SendMessage(pp.HandBotChatId,"Ещё не все закончили свой ход");
                    pp.SellHendler = null;
                }
                    
            } else {
                HandBotFunctions.SendMessage(pp.HandBotChatId,"у тебя слишком много карт, лишних: "+(pp.GetHand().Count-maxCard));
            }
        }
        
    }
}