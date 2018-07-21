using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class SellMenu:Command
    {
        public SellMenu():base(CommandsInfo.SellMenu.StateAllow, CommandsInfo.SellMenu.Name,CommandsInfo.SellMenu.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;  
            var userName = message.Chat.Username;          
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId);
            var tempMessage = "@"+userName+"\n";
            tempMessage += game.GetProfile(userName).SellHendler.GetMessage()+"\n"+CommandsInfo.SellAll.Command;
            HandBotFunctions.SendMessage(chatId,tempMessage);
            //todo message
        }   
         
    }
}