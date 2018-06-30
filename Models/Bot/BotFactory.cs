using System;
using System.Collections.Generic;
using System.Collections;
using Telegram.Bot;
using System.Threading.Tasks;
using ManchkinGameApi.Models.Commands;
namespace ManchkinGameApi.Models.Bot
{
    public class BotFactory
    {        
        private static Dictionary<string,Bot> BotsContainer = new Dictionary<string,Bot>();    
        public static async Task<TelegramBotClient> Initiate(BotSettings botSettings)
        {   
            Bot bot = new Bot(botSettings);
            BotsContainer.Add(botSettings.Name,bot);               
            return await BotsContainer[botSettings.Name].GetClient();
        }
        
        public static async Task<TelegramBotClient> Get(string botName) {
            return await BotsContainer[botName].GetClient();
        }
        public static List<Command> GetCommands(string botName)
        {
            return BotsContainer[botName].Commands;
        }
    }
}
