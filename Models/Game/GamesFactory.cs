using System;
using System.Collections.Generic;
using ManchkinGameApi.Exeptions;
using System.Linq;
namespace ManchkinGameApi.Models.Game
{
    public class GamesFactory {
        public static long gameCount = 0;
        private static Dictionary<long,Game> Games = new Dictionary<long,Game>(); // <gameid, game>
        private static Dictionary<long,long> ChatIdLastGameId = new Dictionary<long,long>();
        private static Dictionary<string,long> userNameMainChatId = new Dictionary<string, long>();
       
        
        public static long CreateGame(long chatId)
        {
            if(ChatIdLastGameId.ContainsKey(chatId)) throw new GameExistExeption(ChatIdLastGameId[chatId]);
            gameCount +=1;
            Games.Add(gameCount,new Game(chatId,gameCount));
            ChatIdLastGameId.Add(chatId,gameCount);
            return gameCount;
        }
        public static void TakeInGamePlace(long chatId,string userName)
        {
            Games[ChatIdLastGameId[chatId]].AddUser(userName);
            userNameMainChatId.TryAdd(userName,chatId);
        }
        public static long GetMainChatId(string userName){
            foreach(var t in userNameMainChatId)
                return userNameMainChatId[userName];
            return 0;  
        }
        public static GameState GetState(long chatId)
        {
            if(ChatIdLastGameId.ContainsKey(chatId))
                return Games[ChatIdLastGameId[chatId]].GameState;
            return GameState.Preparation;
        }
        public static long EndGame(long chatId)
        {
            if( ChatIdLastGameId.ContainsKey(chatId))
            {
                var gameId = ChatIdLastGameId[chatId];
                Games.Remove(gameId);
                ChatIdLastGameId.Remove(chatId); 
                return gameId;
            }
            return -1;
        }
       
        public static long StartGame(long chatId)
        {
            return Games[ChatIdLastGameId[chatId]].StartGame();
        }
        public static Game GetGame(long chatId){
            return Games[ChatIdLastGameId[chatId]];
        }
        

    }
}