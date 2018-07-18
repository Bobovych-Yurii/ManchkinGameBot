using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game
{
    public class PlayerTurnQueue
    {
        private PlayerProfile[] Players = new PlayerProfile[GameParams.MaxPlayers];        
        private int currentId=-1;
        private int lastId=-1;
        public void Add(PlayerProfile userId)
        {
            Players[++lastId] = userId;
            currentId++;
        }
        public PlayerProfile Next()
        {
            if(lastId==-1) throw new Exception();
            if(++currentId > lastId) currentId = 0;
            return Players[currentId];
        }
        public PlayerProfile Current()
        {
            if(currentId == -1) throw new Exception();
            return Players[currentId];
        }        
    }
}