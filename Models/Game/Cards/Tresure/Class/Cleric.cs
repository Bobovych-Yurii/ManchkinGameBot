using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public class Cleric:TresureCard
    {
        public Cleric(string name)
            :base(CardsParamsHendler.GetCard(name)){}
        protected override void InPlay(Game game,string playerUserName)
        {
            var pp = game.GetCurrnetPlayer();
            if(isPlayerTurn(pp,playerUserName))
            {
                pp.SetClass(ClassEnum.Clirick,this.Id);
            }
        }
    }
}