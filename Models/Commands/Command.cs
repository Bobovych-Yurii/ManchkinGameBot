using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using System.Collections.Generic;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public abstract class Command
    {  
        protected Command(GameState stateAllow,string name,string link)
        {
            this.Link = link;
            this.StateAllow = stateAllow;
            this.Name = name;
        }
        public readonly GameState StateAllow;
        public string Name {get;private set;}
        public string Link {get;private set;}
        public abstract void Execute(Message message,ClientWrapper client);

        public virtual bool Contains(string command){
            return command.IndexOf(this.Link) == 0;
        }
        public virtual void IsStateAllow(long chatId)
        {
            GameState nowState = GamesFactory.GetState(chatId);
            if((StateAllow&nowState) == 0) throw new StateNotAllowException();
            
        }
        protected IEnumerator<int> GetParameters(string message,int parameterNum=1){
            if(message.Length< this.Link.Length+2) throw new DefautlMesageException("неправильная команда");
            int starIndex=message.IndexOf('_')+1;
            int endIndex= message.IndexOf('_',starIndex)==-1 ? message.Length : message.IndexOf('_');
           
            for(int i=0;i<=parameterNum;i++) 
            { 
                yield return Convert.ToInt32(message.Substring(starIndex,endIndex-starIndex));   
                             
                starIndex = endIndex;
                endIndex= message.IndexOf('_',starIndex); 
                if(endIndex ==-1) break;                
            }
        }  
        protected string CreateCommandText(string command, IEnumerable<string> arguments){
            foreach(var arg in arguments){
                command+='_'+arg;
            }
            return command; 
        }   
        protected string CreateCommandText(string command,string argument){
            return command+='_'+argument; 
        }  
    }
}