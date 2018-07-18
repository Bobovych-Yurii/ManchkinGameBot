using System;
using System.Collections.Generic;
using System.Collections;
using Telegram.Bot;
using System.Threading.Tasks;
using ManchkinGameApi.Models.Commands;
namespace ManchkinGameApi.Models.Bot
{
    public static class BotFactory
    {        
        public static bool isTest = false;
        private static Dictionary<BotEnum,Bot> BotsContainer = new Dictionary<BotEnum,Bot>();    
        public static async Task<ClientWrapper> Initiate(BotSettings botSettings)
        {   
            Bot bot = new Bot(botSettings);
            BotsContainer.Add(botSettings.BotType,bot);               
            return new ClientWrapper(await BotsContainer[botSettings.BotType].GetClient(),isTest);
        }
        
        public static async Task<ClientWrapper> Get(BotEnum bot) {
            return new ClientWrapper(await BotsContainer[bot].GetClient(),isTest);
        }
        public static List<Command> GetCommands(BotEnum bot)
        {
            return BotsContainer[bot].Commands;
        }
    }
}
