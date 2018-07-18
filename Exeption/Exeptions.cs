using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Exeptions
{   
    public static class ErrorSender{
        public async static void SendExeptionMessage(string message,long chatId,ClientWrapper client)
        {
            await client.SendTextMessageAsync(chatId,message);
        } 
    }
    public class GameExistExeption: Exception
    {   
        public GameExistExeption(long gameId) 
        :base("Для начала новой игры закончите предыдущую игру id:"+gameId
        +"\nзакончить игру "+CommandsInfo.EndGame.Command) { }        
    }
    public class StateNotAllowException:Exception
    {
        public StateNotAllowException()
        :base("Нельзя выполнить в этом состоянии игры"){}
    }

    public class DefautlMesageException:Exception
    {
        public DefautlMesageException(string message)
        :base(message){}
    }
}

