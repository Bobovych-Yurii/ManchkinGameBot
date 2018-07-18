using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Commands
{
    public class PlayCard:Command
    {
        public PlayCard():base(CommandsInfo.PlayCard.StateAllow, CommandsInfo.PlayCard.Name,CommandsInfo.PlayCard.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var cardId = GetParameters(message.Text,1);
            cardId.MoveNext();
            var card = CardsList.GetCard(cardId.Current);
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 

            card.Play(game,userName);   
            
        }   
         
    }
}