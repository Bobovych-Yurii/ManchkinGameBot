using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
namespace ManchkinGameApi.Models.Commands
{
    public class EndGame:Command
    {       
        public EndGame():base( CommandsInfo.EndGame.StateAllow, CommandsInfo.EndGame.Name){}
        public override void Execute(Message message,TelegramBotClient client){
            var chatId = message.Chat.Id;
            var gameId =  GamesFactory.EndGame(chatId);
            
            if(gameId != -1){
              client.SendTextMessageAsync(chatId,"end game "+gameId);
            }  else {
                client.SendTextMessageAsync(chatId,"error end game");
            }
        }
        
    }
}