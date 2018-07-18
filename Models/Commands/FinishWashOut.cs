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
    public class FinishWashOut:Command
    {
        public FinishWashOut():base(CommandsInfo.FinishWashOut.StateAllow, CommandsInfo.FinishWashOut.Name,CommandsInfo.FinishWashOut.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var mainChatId = GamesFactory.GetMainChatId(userName);  
            var game = GamesFactory.GetGame(mainChatId); 
 
            var pp = game.GetProfile(userName);
            if(pp.PlayerState != PlayerState.WashOut) throw new DefautlMesageException("Не ваш ход");
            game.FinishWashOut(pp);
        }   
         
    }
}