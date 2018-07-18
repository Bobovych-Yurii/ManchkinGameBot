using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class GiveCard:Command
    {
        public GiveCard():base(CommandsInfo.GiveCard.StateAllow, CommandsInfo.GiveCard.Name,CommandsInfo.GiveCard.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;            
            var gameId = GetParameters(message.Text,2);
            //todo givefunc
        }   
         
    }
}