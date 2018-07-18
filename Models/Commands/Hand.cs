using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class HandComand:Command
    {       
        public HandComand():base( CommandsInfo.Hand.StateAllow, CommandsInfo.Hand.Name,CommandsInfo.Hand.Command){}
        public override void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var username = message.Chat.Username;
            var mainChatId = GamesFactory.GetMainChatId(username);         
            var game = GamesFactory.GetGame(mainChatId);  
            
            HandBotFunctions.SendHand(chatId,game.GetProfile(username).GetHand());
        }
        
    }
}