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
    public class CallHelp:Command
    {
        public CallHelp():base(CommandsInfo.CallHelp.StateAllow, CommandsInfo.CallHelp.Name,CommandsInfo.CallHelp.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var mainChatId = GamesFactory.GetMainChatId(userName);  
            var game = GamesFactory.GetGame(mainChatId); 

            if(game.GameState == GameState.Fight) throw new DefautlMesageException("Снйчас не идет бой");
            if(game.GetCurrnetPlayer().UserName != userName) throw new DefautlMesageException("Не ваш ход");
            
            HandBotFunctions.SendUsersList(chatId,game.GameId,"Выберите помощника",
            "help",game.PlayersList(userName)); //todo helpcommand
        }   
         
    }
}