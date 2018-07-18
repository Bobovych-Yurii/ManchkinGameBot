using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class StartHandBot:Command
    {
        public StartHandBot():base(CommandsInfo.StartHandBot.StateAllow, CommandsInfo.StartHandBot.Name,CommandsInfo.StartHandBot.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id; 
            var userName = message.Chat.Username;
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var gameId = GetParameters(message.Text);
            if(!gameId.MoveNext()) throw new DefautlMesageException("вы не указали id игры");
            
            GamesFactory.GetGame(mainChatId).SetHandBot(chatId,userName);
            HandBotFunctions.SendKeyboadrd(chatId,Game.GameState.StartTurn,
                GamesFactory.GetGame(mainChatId).GetProfile(userName).PlayerState);
        }     
    }
}