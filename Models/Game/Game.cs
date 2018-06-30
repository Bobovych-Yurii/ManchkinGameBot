using System;
using System.Collections;
using System.Collections.Generic;
using Telegram.Bot;
namespace ManchkinGameApi.Models.Game
{
    public class Game
    {
        public long GameId {get;private set;}
        private List<long> UserIdList = new List<long>();
        public long ChatId {get;private set;}
        public byte GameState = 0b0000_0001;

        public Game(long chatId,long gameId)
        {
            ChatId = chatId;
            GameId = gameId;
        }
        public void AddUser(long userId,int place=-1)
        {
            if(!UserIdList.Contains(userId))
                UserIdList.Add(userId);   
        }
        public byte StartGame()
        {
            GameState = (byte)ManchkinGameApi.Models.Game.GameState.StartGame;
            return GameState;
        }
    }
}