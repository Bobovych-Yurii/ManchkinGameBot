using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
namespace ManchkinGameApi.Models.Game.Cards
{
    public class ClassParams:CardParams
    {
        public ClassEnum ClassType {get;}
        public ClassParams(string name,int id,string gameImagePath,ClassEnum classType,
        CardType ct=CardType.Class,GameState gs = GameState.OwnTurn, CardUsage cu = CardUsage.Self)
            :base(name,id,gameImagePath,ct,gs,cu)
        {
            ClassType = classType;
        }
    }
}