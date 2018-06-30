using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
namespace ManchkinGameApi.Exeptions
{   
    public static class ErrorSender{
        public async static void SendExeptionMessage(string message,long chatId,TelegramBotClient client)
        {
            await client.SendTextMessageAsync(chatId,message);
        } 
    }
    public class GameExistExeption: Exception
    {   
        public GameExistExeption(long gameId)
        :base("To start new game finish last game id:"+gameId
        +" use "+CommandsInfo.EndGame.Command) { }        
    }
    public class StateNotAllowException:Exception
    {
        public StateNotAllowException()
        :base("command no allow in this state"){}
    }
}

