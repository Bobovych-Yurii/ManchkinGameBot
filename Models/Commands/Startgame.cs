using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Commands
{
    public class StartGame:Command
    {
        public StartGame():base(CommandsInfo.StarGame.StateAllow, CommandsInfo.StarGame.Name){}
        public override  void Execute(Message message,TelegramBotClient client){
            var chatId = message.Chat.Id;            
            var status = GamesFactory.StartGame(chatId);
            client.SendTextMessageAsync(chatId,"start game");
        }       
    }
}