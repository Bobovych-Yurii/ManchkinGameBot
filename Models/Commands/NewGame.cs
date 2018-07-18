using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class NewGame:Command
    {
        public NewGame():base(CommandsInfo.NewGame.StateAllow, CommandsInfo.NewGame.Name,CommandsInfo.NewGame.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;            
            long gameId = GamesFactory.CreateGame(chatId);
            client.SendTextMessageAsync(chatId,"Новая игра id: "+gameId
                    +"\nЗаймите меcто в игре: "+ CommandsInfo.TakeInGamePlace.Command
                    +"\nПосле готовноти начните игру: "+CommandsInfo.StarGame.Command);
        }       
    }
}