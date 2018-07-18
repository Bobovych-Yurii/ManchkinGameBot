using System;
using System.Collections.Generic;
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
    public class SendStats:Command
    {
        public SendStats():base(CommandsInfo.Class.StateAllow, CommandsInfo.Class.Name,CommandsInfo.Class.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id; 
            var userName = message.Chat.Username;
            var mainChatId = GamesFactory.GetMainChatId(userName);         
            var game = GamesFactory.GetGame(mainChatId);  
            var cards = game.GetProfile(userName).GetClassCards();
            
            HandBotFunctions.SendEquipmentCards(chatId,cards,"====ВАШ СТАТЫ====");
             
            
        }   
         
    }
}