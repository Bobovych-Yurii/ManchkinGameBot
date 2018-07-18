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
using ManchkinGameApi.Models.Game.Player.Items;
namespace ManchkinGameApi.Models.Commands
{
    public class SendBodyEquipment:Command
    {
        protected BodyPartsEnum bp;

        public SendBodyEquipment(CommandInfo ci,BodyPartsEnum bp):base(ci.StateAllow, ci.Name,ci.Command){this.bp=bp;} 
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;
            var mainChatId = GamesFactory.GetMainChatId(userName);         
            var game = GamesFactory.GetGame(mainChatId);  
            var cards = game.GetProfile(userName).GetItems(bp);
            HandBotFunctions.SendEquipmentCards(chatId,cards,"===="+this.Link.ToUpper()+"====");
        }   
         
    }
}