using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public class ClassCard:TresureCard
    {
        private ClassEnum classType;
        public ClassCard(string name)
            :base(CardsParamsHendler.GetCard(name))
        {
            var temp = CardsParamsHendler.GetCard(name) as ClassParams;
            this.classType = temp.ClassType;
        }
        protected override void InPlay(Game game,string playerUserName)
        {
            var pp = game.GetCurrnetPlayer();
            if(isPlayerTurn(pp,playerUserName))
            {
                pp.SetClass(classType,this.Id);
            }
        }
    }
}