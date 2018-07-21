using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class UndoSell:Command
    {
        public UndoSell():base(CommandsInfo.UndoSell.StateAllow, CommandsInfo.UndoSell.Name,CommandsInfo.UndoSell.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;  
            var userName = message.Chat.Username;          
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 
            var cardId = GetParameters(message.Text);
            if(!cardId.MoveNext()) throw new DllNotFoundException("что-то пошло не так с продажей");
            game.GetProfile(userName).SellHendler.GetOut(cardId.Current);
            //todo message
        }   
         
    }
}