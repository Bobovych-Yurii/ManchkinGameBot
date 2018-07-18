using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class EquipmentMenu:Command
    {
        public EquipmentMenu():base(CommandsInfo.Equipment.StateAllow, CommandsInfo.Equipment.Name,CommandsInfo.Equipment.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var mainChatId = GamesFactory.GetMainChatId(userName);  
            HandBotFunctions.SendEqupmentKeyBoard(chatId);
             
            
        }   
         
    }
}