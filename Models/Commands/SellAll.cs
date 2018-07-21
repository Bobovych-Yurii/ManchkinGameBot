using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
namespace ManchkinGameApi.Models.Commands
{
    public class SellAll:Command
    {
        public SellAll():base(CommandsInfo.SellAll.StateAllow, CommandsInfo.SellAll.Name,CommandsInfo.SellAll.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;  
            var userName = message.Chat.Username;          
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 
            var player = game.GetProfile(userName);
            var levels = game.GetProfile(userName).SellHendler.SellAll();
            for(int i=0;i<levels;i++)
            {
                player.LevelUp();
            }
            //todo message
        }   
         
    }
}