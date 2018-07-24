using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game
{
    public class PlayerTurnQueue
    {
        private List<PlayerProfile> Players = new List<PlayerProfile>();        
        private int currentId=-1;
        private int lastId=-1;
        public void Add(PlayerProfile userId)
        {
            lastId++;
            Players.Add(userId);
            currentId=0;
        }
        public PlayerProfile Next()
        {
            if(lastId==-1) throw new DefautlMesageException("new level exeption"); /// exception
            if(++currentId > lastId) currentId = 0;
            return Players[currentId];
        }
        public PlayerProfile Current()
        {
            if(currentId == -1) throw new DefautlMesageException("current error"); /// exception
            
            return Players[currentId];
        }  
        public PlayerProfile GetNextTo(PlayerProfile pp,int count=1)
        {
            var index = Players.IndexOf(pp);
            if(index == -1) throw new IndexOutOfRangeException();
            
            return Players[(index+count)%lastId];
        }  
        public PlayerProfile GetPeviousTo(PlayerProfile pp,int count=1)
        {
            var index = Players.IndexOf(pp);
            if(index == -1) throw new IndexOutOfRangeException();
            
            return Players[lastId-((count-index+lastId)%lastId+1)];
        }     
    }
}