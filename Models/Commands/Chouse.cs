using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class Chouse:Command
    {
        public Chouse():base(CommandsInfo.Chouse.StateAllow, CommandsInfo.Chouse.Name,CommandsInfo.Chouse.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;  
            var userName = message.Chat.Username;          
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 
            var choseInex = GetParameters(message.Text);
            if(!choseInex.MoveNext()) throw new DllNotFoundException("что-то пошло не так с выбором");
            game.Chouse.MakeChouse(game.GetProfile(userName),choseInex.Current);
            //todo message
        }   
         
    }
}