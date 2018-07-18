using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Bot;
using System.Linq;
namespace ManchkinGameApi.Models.Commands
{
    public class StartGame:Command
    {
        public StartGame():base(CommandsInfo.StarGame.StateAllow, CommandsInfo.StarGame.Name,CommandsInfo.StarGame.Command){}
        public override void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;            
            var gameId = GamesFactory.StartGame(chatId);
            client.SendTextMessageAsync(chatId,"Старт игры\nОтправте команду в бот @"
                +new ManckinHandBotSettings().Name+"\n"+CreateCommandText(CommandsInfo.StartHandBot.Command,gameId.ToString()));
        }       
    }
}