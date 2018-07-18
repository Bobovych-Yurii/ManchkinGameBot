using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Functions;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Commands
{
    public class FinishCharity:Command
    {
        public FinishCharity():base(CommandsInfo.EndTurn.StateAllow, CommandsInfo.EndTurn.Name,CommandsInfo.EndTurn.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var mainChatId = GamesFactory.GetMainChatId(userName);  
            var game = GamesFactory.GetGame(mainChatId); 
 
            var pp = game.GetProfile(userName);
            if(pp.PlayerState != PlayerState.Charity) throw new DefautlMesageException("Не ваш ход");
            game.FinishCharity(pp);
        }   
         
    }
}