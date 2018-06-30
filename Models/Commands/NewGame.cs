using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Commands;
namespace ManchkinGameApi.Models.Commands
{
    public class NewGame:Command
    {
        public NewGame():base(CommandsInfo.NewGame.StateAllow, CommandsInfo.NewGame.Name){}
        public override  void Execute(Message message,TelegramBotClient client){
            var chatId = message.Chat.Id;            
            long gameId = GamesFactory.CreateGame(chatId);
            client.SendTextMessageAsync(chatId,"start new game id: "+gameId
                    +"\ntake in game place: "+ CommandsInfo.TakeInGamePlace.Command
                    +"\nthen use "+CommandsInfo.StarGame.Command);
        }       
    }
}