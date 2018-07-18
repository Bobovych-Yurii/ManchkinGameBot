using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class SellCard:Command
    {
        public SellCard():base(CommandsInfo.SellCard.StateAllow, CommandsInfo.SellCard.Name,CommandsInfo.SellCard.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;  
            var userName = message.Chat.Username;          
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 
            //todo sellfunc
        }   
         
    }
}