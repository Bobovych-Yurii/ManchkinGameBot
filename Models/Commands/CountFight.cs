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
    public class CountFight:Command
    {
        public CountFight():base(CommandsInfo.CountFight.StateAllow, CommandsInfo.CountFight.Name,CommandsInfo.CountFight.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var mainChatId = GamesFactory.GetMainChatId(userName);  
            var game = GamesFactory.GetGame(mainChatId); 

            if(game.GetCurrnetPlayer().UserName != userName) throw new DefautlMesageException("Не ваш ход");
            game.CountFight(chatId);
             
            
        }   
         
    }
}