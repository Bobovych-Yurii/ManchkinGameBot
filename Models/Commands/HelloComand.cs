using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class HelloCommand:Command
    {
        public HelloCommand():base(CommandsInfo.Hello.StateAllow, CommandsInfo.Hello.Name, CommandsInfo.Hello.Command){}
        public override void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendTextMessageAsync(chatId,"hello");
        }       
    }
}