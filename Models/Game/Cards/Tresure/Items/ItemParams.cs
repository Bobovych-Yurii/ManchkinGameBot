using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
namespace ManchkinGameApi.Models.Game.Cards
{
    public class ItemParams:CardParams
    {
        public ClassEnum ForClass {get;}
        public RaceEnum ForRace {get;}
        public int Price {get;}
        public BodyPartsEnum BodyPart {get;}
        public int ItemSlots{get;}
        public int DefaultBonus{get;}
        public bool IsBig{get;}
        public ItemParams(string name,int id,string gameImagePath,CardType ct,GameState gs,
            CardUsage cu,BodyPartsEnum bp,int slots,ClassEnum forClass,RaceEnum forRace,int price,int defaultBonus,bool isBig)
            :base(name,id,gameImagePath,ct,gs,cu)
        {
            ForClass = forClass;
            Price = price;
            BodyPart = bp;
            ItemSlots = slots;
            DefaultBonus = defaultBonus;
            ForRace = forRace;
            IsBig = isBig;
        }
    }
}