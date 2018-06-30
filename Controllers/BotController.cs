using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManchkinGameApi.Models;
using ManchkinGameApi.Models.Bot;
using Telegram.Bot.Types;
using ManchkinGameApi.Exeptions;

namespace ManchkinGameApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BotController : Controller
    {
         [HttpPost]
        public async Task<OkResult> ManchkinGame([FromBody]Update update)
        {
            string botName = (new ManckinGameBotSettings()).Name;
            var client = await BotFactory.Get(botName);                      
            var message = update.Message;
            try
            {                
                ExecuteCommand(botName,update,client);                
            } 
            catch(StateNotAllowException ex)
            {
                ManchkinGameApi.Exeptions.ErrorSender.SendExeptionMessage(ex.Message,message.Chat.Id,client);
            } 
            catch(GameExistExeption ex) 
            {  
                ManchkinGameApi.Exeptions.ErrorSender.SendExeptionMessage(ex.Message,message.Chat.Id,client);
            } catch { Console.WriteLine("Unknown exeption manchin Bot Action");} 
            return new OkResult();
        }
        [HttpPost]
        public async Task<OkResult> ManchkinHand([FromBody]Update update)
        {
            string botName = (new ManckinGameBotSettings()).Name;
            var client = await BotFactory.Get(botName);                      
            var message = update.Message;
            try
            {                
                ExecuteCommand(botName,update,client);                
            } 
            catch{Console.WriteLine("Unknown exeption manchin Hand Action");}
            return new OkResult();
        }
        private void ExecuteCommand(string botName,Update update,Telegram.Bot.TelegramBotClient client)
        {            
            var commands = BotFactory.GetCommands(botName);  
            var message = update.Message;
            foreach(var command in commands)
                {                
                    if(command.Contains(message.Text))
                    {
                        command.IsStateAllow(message.Chat.Id);
                        command.Execute(message,client);
                        break;
                    }
                }
        }
        
    }
}
