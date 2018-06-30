using System;
using System.Collections.Generic;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game
{
    public class GamesFactory {
        public static long gameCount = 0;
        private static Dictionary<long,Game> Games = new Dictionary<long,Game>();
        private static Dictionary<long,long> ChatIdLastGameId = new Dictionary<long,long>();
        public static long CreateGame(long chatId)
        {
            if(ChatIdLastGameId.ContainsKey(chatId)) throw new GameExistExeption(ChatIdLastGameId[chatId]);
            gameCount +=1;
            Games.Add(gameCount,new Game(chatId,gameCount));
            ChatIdLastGameId.Add(chatId,gameCount);
            return gameCount;
        }
        public static void TakeInGamePlace(long chatId,long userId)
        {
            Games[ChatIdLastGameId[chatId]].AddUser(userId);
        }
        public static byte GetState(long chatId)
        {
            if(ChatIdLastGameId.ContainsKey(chatId))
                return Games[ChatIdLastGameId[chatId]].GameState;
            return 0b0000_0001;
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
        public static byte StartGame(long chatId)
        {
             return Games[ChatIdLastGameId[chatId]].StartGame();
        }

    }
}