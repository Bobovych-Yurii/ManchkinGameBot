using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class SendUsersLevel:Command
    {
        public SendUsersLevel():base(CommandsInfo.PlayersLevel.StateAllow, CommandsInfo.PlayersLevel.Name,CommandsInfo.PlayersLevel.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;  
            var userName = message.Chat.Username;          
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 

            var playersLevel = game.GetPlayersLevel();
            string temp="Уровни играков: ";
            foreach (var player in playersLevel)
            {
                temp+="@"+player.Key +" "+player.Value;
            }
            HandBotFunctions.SendMessage(chatId,temp);
        }   
         
    }
}