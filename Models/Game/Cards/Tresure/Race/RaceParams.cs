using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
namespace ManchkinGameApi.Models.Game.Cards
{
    public class RaceParams:CardParams
    {
        public RaceEnum RaceType {get;}
        public RaceParams(string name,int id,string gameImagePath,RaceEnum raceType,
        CardType ct=CardType.Class,GameState gs = GameState.OwnTurn, CardUsage cu = CardUsage.Self)
            :base(name,id,gameImagePath,ct,gs,cu)
        {
            RaceType = raceType;
        }
    }
}