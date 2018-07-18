using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Game.Cards;
namespace ManchkinGameApi.Models.Functions
{
    public static class GameBotFunctions
    {
        private static ClientWrapper cw = BotFactory.Get(BotEnum.GameBot).Result;
        public static void SendMessage(long chatId,string message)
        {
            cw.SendTextMessageAsync(chatId,message);
        }
        public static void ShowUserCard(long charId,Card card,string message){
            cw.SendPhoto(charId,card.GameImagePath,message);
        }
    }
}