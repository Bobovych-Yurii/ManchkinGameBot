using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Commands
{
    public class TakeIngamePlace:Command
    {
        public TakeIngamePlace():base(CommandsInfo.TakeInGamePlace.StateAllow, CommandsInfo.TakeInGamePlace.Name){}
        public override void Execute(Message message,TelegramBotClient client){
            var chatId = message.Chat.Id;
            var userId = message.From.Id;
            GamesFactory.TakeInGamePlace(chatId,userId);
            client.SendTextMessageAsync(chatId,"user "+message.From.Username+"added to game");
        }                
    }
}