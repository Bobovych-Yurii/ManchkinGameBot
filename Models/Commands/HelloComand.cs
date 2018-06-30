using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
namespace ManchkinGameApi.Models.Commands
{
    public class HelloCommand:Command
    {
        public HelloCommand():base(CommandsInfo.Hello.StateAllow, CommandsInfo.Hello.Name){}
        public override void Execute(Message message,TelegramBotClient client){
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendTextMessageAsync(chatId,"hello");
        }       
    }
}