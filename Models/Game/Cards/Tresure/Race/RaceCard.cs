using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public class RaceCard:TresureCard
    {
        private RaceEnum raceType;
        public RaceCard(string name)
            :base(CardsParamsHendler.GetCard(name))
        {
            var temp = CardsParamsHendler.GetCard(name) as RaceParams;
            this.raceType = temp.RaceType;
        }
        protected override void InPlay(Game game,string playerUserName)
        {
            var pp = game.GetCurrnetPlayer();
            if(isPlayerTurn(pp,playerUserName))
            {
                pp.SetRace(raceType,this);
            }
        }
    }
}