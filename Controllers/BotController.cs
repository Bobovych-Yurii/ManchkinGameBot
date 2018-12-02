using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManchkinGameApi.Models;
using ManchkinGameApi.Models.Bot;
using Telegram.Bot.Types;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game;

namespace ManchkinGameApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BotController : Controller
    {
        
        [HttpPost]
        public async Task<OkResult> ManchkinGame([FromBody]Update update)
        {
            try{
            var client = await BotFactory.Get(BotEnum.GameBot); 
            ExecuteCommand(BotEnum.GameBot,update,client,true);    
            }
            catch {
             return new OkResult();
            }
            return new OkResult();
        }
        [HttpPost]
        public async Task<OkResult> ManchkinHand([FromBody]Update update)
        {
            try{
            var client = await BotFactory.Get(BotEnum.HandBot);                      
            var message = update.Message;
            ExecuteCommand(BotEnum.HandBot,update,client,false);
             }
            catch {
             return new OkResult();
            }
            return new OkResult();
        }
        private void ExecuteCommand(BotEnum bot,Update update,ClientWrapper client,bool isMainChat)
        {    
            var commands = BotFactory.GetCommands(bot);  
            Message message;
            if(update.Message != null){ // check if request is command or button
                message = update.Message; // for command
            }else{
                message = update.CallbackQuery.Message;   // for press button
                message.Text = update.CallbackQuery.Data.ToString();  // in CallbackQuery message.Text == press button,
                                                                    // change press button to command
            }
            try
            { 
                foreach(var command in commands)
                {                
                    if(command.Contains(message.Text))
                    {
                        var id = message.Chat.Id;
                        if(!isMainChat)
                            id =  GamesFactory.GetMainChatId(message.Chat.Username);   
                        command.IsStateAllow(id);
                        command.Execute(message,client);
                        break;
                    }
                }
            }

            catch(DefautlMesageException ex)
            {
                ManchkinGameApi.Exeptions.ErrorSender.SendExeptionMessage(ex.Message,message.Chat.Id,client);
            }
            catch(StateNotAllowException ex)
            {
                ManchkinGameApi.Exeptions.ErrorSender.SendExeptionMessage(ex.Message,message.Chat.Id,client);
            } 
            catch(GameExistExeption ex) 
            {  
                ManchkinGameApi.Exeptions.ErrorSender.SendExeptionMessage(ex.Message,message.Chat.Id,client);
            } 
        }
        
    }
}
