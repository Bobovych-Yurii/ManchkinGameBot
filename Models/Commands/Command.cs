using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;

namespace ManchkinGameApi.Models.Commands
{
    public abstract class Command
    {  
        protected Command(byte stateAllow,string name)
        {
            this.StateAllow = stateAllow;
            this.Name = name;
        }
        public byte StateAllow {get; private set;} = 0b1111_1111;
        public string Name {get;private set;}

        public abstract void Execute(Message message,TelegramBotClient client);

        public virtual bool Contains(string command){
            return command.Contains(this.Name);
        }
        public virtual void IsStateAllow(long chatId)
        {
            byte nowState = GamesFactory.GetState(chatId);
            if( (byte)(StateAllow&nowState) == 0b0000_0000) throw new StateNotAllowException();
            
        }
    }
}