using System;
using System.Collections.Generic;
namespace ManchkinGameApi.Models.Game
{
    public class UserTurnQueue
    {
        private long[] UsersId = new long[5];
        
        private int currentId=-1;
        private int lastId=-1;
        public void Add(long userId)
        {
            UsersId[++lastId] = userId;
            currentId++;
        }
        public long Next()
        {
            if(lastId==-1) throw new Exception();
            if(++currentId > lastId) currentId = 0;
            return UsersId[currentId];
        }
        public long GetCurrent()
        {
            if(currentId == -1) throw new Exception();
            return UsersId[currentId];
        }        
    }


    public class UserNode
    {
        public UserNode(long userId,string userName){
            this.UserId = userId;
            this.UserName = userName;
        }
        public long UserId;
        public string UserName;
    }
}