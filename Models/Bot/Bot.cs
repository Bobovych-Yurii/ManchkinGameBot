using System;
using System.Collections.Generic;
using System.Collections;
using Telegram.Bot;
using System.Threading.Tasks;
using ManchkinGameApi.Models.Commands;
namespace ManchkinGameApi.Models.Bot
{
    //public static Dictionary<> BotContainer
    class Bot 
    {
        private TelegramBotClient client;
        private string url;
        private string key;
        public List<Command> Commands {get;protected set;}       

        public Bot(BotSettings botSettings)
        {
            Commands = botSettings.Commands;
            url = botSettings.Url;
            key = botSettings.Key;
        }
        public async Task<TelegramBotClient> GetClient()
        {
             if(client != null){
                return client;
            }
            client = new TelegramBotClient(this.key);             
            await client.SetWebhookAsync(this.url);
            return client;
        }
    }    
}