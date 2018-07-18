using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Commands
{
    public class KickDoor:Command
    {
        public KickDoor():base(CommandsInfo.KickDoor.StateAllow, CommandsInfo.KickDoor.Name,CommandsInfo.KickDoor.Command){}
        public override void Execute(Message message,ClientWrapper client){
            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;            
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            var game = GamesFactory.GetGame(mainChatId); 

            if(game.GetCurrnetPlayer().UserName != userName) throw new DefautlMesageException("Вы можете выбивать девери только в свой ход");
            
            game.KickDoor();
            
            
        }   
         
    }
}