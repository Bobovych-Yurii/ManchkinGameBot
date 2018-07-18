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
namespace ManchkinGameApi.Models.Game
{
    public class Game
    {
        public long GameId {get;private set;}
        private readonly List<PlayerProfile> players = new List<PlayerProfile>();
        
        public long ChatId {get;private set;}
        public GameState GameState = GameState.Preparation;
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
        public void SetHandBot(long playerChatId,string playerName)
        {
            var tempPp = players.Where(pp =>pp.UserName == playerName).First();
            if(!tempPp.GetPlayerStatistic().IsStartCardsTaken)
            {
                tempPp.HandBotChatId = playerChatId;
                for(int i=0; i < GameParams.StartCardsCount;i++){
                    
                    var resived = tempPp.TakeCard(deckHendler.GetTresureCard());
                    if(resived as TresureCard !=null) deckHendler.TresureCardResived(resived as TresureCard);
                    //todo give 4 door cards
                }
            
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
        public void ToStock(Card card,string playerName){
            players.Where(p=>p.UserName == playerName).First().Discard(card);
            deckHendler.ToStock(card);
        }

        public DoorCard GetDoorCard()
        {
            return deckHendler.GetDoorCard();
        }
        public void KickDoor()
        {
            GameState = GameState.KickDoor;
            turnQueur.Current().PlayerState = PlayerState.Fight;
            var card = deckHendler.GetDoorCard();
            //todo otherecard type
            if(card.CardType == CardType.Enemy)
            {
                GameState = GameState.Fight;
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
        }
        public void FinishFight(){
            if(fightHendler == null) throw new DefautlMesageException("Сейчас не идет бой");

            var result = fightHendler.Finish();
            if(result)
            { // win
            fightHendler.Win();
            GameState = GameState.Charity;
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
        public bool UseBuffCard(BuffCard card)
        {   
            if(fightHendler == null) throw new DefautlMesageException("Сейчас не идет бой");
            fightHendler.UseBuff(card);
            return false;
        }
        public void PlayerTakeCard(PlayerProfile pp,CardType ct,bool openTake)
        {
            switch(ct)
            {
                case CardType.Tresure:
                    var resived = pp.TakeCard(deckHendler.GetTresureCard());            
                    if(resived as TresureCard !=null)
                    {
                        deckHendler.TresureCardResived(resived as TresureCard);
                        HandBotFunctions.SendCards(pp.HandBotChatId,new List<Card>{resived},"Берете карту");
                        if(openTake) 
                        {
                            GameBotFunctions.ShowUserCard(ChatId,resived,"@"+pp.UserName+" получает карту");
                        }
                    }
                    break;
                default: throw new Exception();
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
        public void FinishWashOut(PlayerProfile pp)
        {
            var finish = washOutHandler.Finish(pp);
            if(finish)
            {
                GameState = GameState.Charity;
                HandBotFunctions.SendMessage(GetCurrnetPlayer().HandBotChatId,"Можешь сыграть свои карты");
                GameBotFunctions.SendMessage(ChatId,"Бой закончен");
                HandBotFunctions.SendKeyboadrd(pp.HandBotChatId,GameState,pp.PlayerState);
            }
        }
        public void FinishCharity(PlayerProfile pp)
        {
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
                    GameState = GameState.StartTurn;
                    turnQueur.Next();
                    var current = turnQueur.Current();
                    current.PlayerState = PlayerState.OwnTurn;
                    GameBotFunctions.SendMessage(ChatId,"Начинаеться ход @"+current.UserName);
                    HandBotFunctions.SendMessage(current.HandBotChatId,"Твой ход");
                } else {
                    HandBotFunctions.SendMessage(pp.HandBotChatId,"Ещё не все закончили свой ход");
                    
                }
                    
            } else {
                HandBotFunctions.SendMessage(pp.HandBotChatId,"у тебя слишком много карт, лишних: "+(pp.GetHand().Count-maxCard));
            }
        }
        
    }
}