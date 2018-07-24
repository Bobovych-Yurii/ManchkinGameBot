using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class SendMainMenu:Command
    {
        public SendMainMenu():base(CommandsInfo.GetMainMenu.StateAllow, CommandsInfo.GetMainMenu.Name,CommandsInfo.GetMainMenu.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id; 
            var userName = message.Chat.Username;
            var mainChatId = GamesFactory.GetMainChatId(userName);  
            HandBotFunctions.SendKeyboadrd(chatId,GamesFactory.GetState(mainChatId),
                GamesFactory.GetGame(mainChatId).GetProfile(userName).PlayerState);//to do get gameState
        }     
    }
}