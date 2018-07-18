using System;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public class LevelUp:TresureCard
    {
        public LevelUp(string name)
            :base(CardsParamsHendler.GetCard(name)){}
        protected override void InPlay(Game game,string playerUserName)
        {
            var pp = game.GetCurrnetPlayer();
            Console.WriteLine("inPlay"+isPlayerTurn(pp,playerUserName));
            if(isPlayerTurn(pp,playerUserName))
            {
                pp.LevelUp();
            }
            
        }
    }
}