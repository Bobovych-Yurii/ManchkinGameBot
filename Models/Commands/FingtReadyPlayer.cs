using System;
using Telegram.Bot.Types;
using Telegram.Bot;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Commands
{
    public class FingtReadyPlayer:Command
    {
        public FingtReadyPlayer():base(CommandsInfo.FingtReadyPlayer.StateAllow, CommandsInfo.FingtReadyPlayer.Name,CommandsInfo.FingtReadyPlayer.Command){}
        public override  void Execute(Message message,ClientWrapper client){
            
            var chatId = message.Chat.Id; 
            var userName = message.Chat.Username;
            var mainChatId = GamesFactory.GetMainChatId(userName);           
            
            
            var game = GamesFactory.GetGame(mainChatId);
            if(game == null) throw new DefautlMesageException("игра еще не началась");
            game.FingtReadyPlayer(game.GetProfile(userName));
            HandBotFunctions.SendKeyboadrd(chatId,Game.GameState.Charity,
                GamesFactory.GetGame(mainChatId).GetProfile(userName).PlayerState,"Больше вы не участуете в битвер");
            
            
        }     
    }
}