using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class TakeIngamePlace:Command
    {
        public TakeIngamePlace():base(CommandsInfo.TakeInGamePlace.StateAllow, CommandsInfo.TakeInGamePlace.Name,CommandsInfo.TakeInGamePlace.Command){}
        public override void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.From.Username;
            GamesFactory.TakeInGamePlace(chatId,userName);
            client.SendTextMessageAsync(chatId,message.From.Username+" доюавлен в игру");
        }                
    }
}