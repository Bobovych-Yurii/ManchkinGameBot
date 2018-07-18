using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class EndGame:Command
    {       
        public EndGame():base( CommandsInfo.EndGame.StateAllow, CommandsInfo.EndGame.Name,CommandsInfo.EndGame.Command){}
        public override void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var gameId =  GamesFactory.EndGame(chatId);
            
            if(gameId != -1){
              client.SendTextMessageAsync(chatId,"Игра окончена Id:"+gameId);
            }  else {
                client.SendTextMessageAsync(chatId,"Ошибка окончания игры");
            }
        }
        
    }
}