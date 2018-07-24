using System;
using System.Collections.Generic;
using System.Collections;
using Telegram.Bot;
using System.Threading.Tasks;
using ManchkinGameApi.Models.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using System.IO;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ManchkinGameApi.Models.Bot
{
    public class ClientWrapper
    {    
        private readonly bool isTest;
        private readonly TelegramBotClient client;
        public ClientWrapper(TelegramBotClient client=null, bool test = true)
        {
            isTest = test;
            this.client = client;
        }
        public async Task<Message> SendTextMessageAsync(long chatId, string text,IReplyMarkup keyboard = null)
        {
            if(isTest)
            {
                return null;
            }
            else
            {
               return await client.SendTextMessageAsync(chatId,text,ParseMode.Default,false,false,0,keyboard);
            }
        } 
        public async Task<Message> SendPhoto(long chatId,string pathToFile,string message="",IReplyMarkup keyboard=null){
            if(isTest)
            { return null;}//todo test
            else{
                InputOnlineFile imageFile = new InputOnlineFile(new MemoryStream(System.IO.File.ReadAllBytes("wwwroot/"+pathToFile)));
                
                return await client.SendPhotoAsync(chatId,imageFile,message,ParseMode.Default,false,0,keyboard);
            }
        }
    }
}