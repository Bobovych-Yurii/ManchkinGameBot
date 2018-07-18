using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
namespace ManchkinGameApi.Models.Game.Cards
{
    public static class CardsParamsHendler
    {
        private static readonly Dictionary<string,CardParams> cardsParams = new Dictionary<string,CardParams>(){
        /// class
            {"cleric_1",new CardParams("cleric_1", GenerateId(),@"/cards/tresure/class/cleric_class.PNG",CardType.Class,GameState.All,CardUsage.Self)},
            {"cleric_2",new CardParams("cleric_2", GenerateId(),@"/cards/tresure/class/cleric_class_2.PNG",CardType.Class,GameState.All,CardUsage.Self)},            
            {"cleric_3",new CardParams("cleric_3", GenerateId(),@"/cards/tresure/class/cleric_class_3.PNG",CardType.Class,GameState.All,CardUsage.Self)},
        /// items    
            {"archer",new ItemParams("archer",GenerateId(),@"/cards/tresure/items/archer.PNG",CardType.Item,GameState.StartTurn
                ,CardUsage.Self,BodyPartsEnum.Hand,2,ClassEnum.Any,RaceEnum.Elf,800,4,false)},
            {"armor",new ItemParams("armor", GenerateId(),@"/cards/tresure/items/armor.PNG",CardType.Item,GameState.StartTurn
                ,CardUsage.Self,BodyPartsEnum.Chest,1,ClassEnum.Any,RaceEnum.Dwarf,400,3,false)},
            {"backet",new ItemParams("backet",GenerateId(),@"/cards/tresure/items/backet.PNG",CardType.Item,GameState.StartTurn
                ,CardUsage.Self,BodyPartsEnum.Head,1,ClassEnum.Any,RaceEnum.Any,200,1,false)},
            {"club_2",new ItemParams("club_2", GenerateId(),@"/cards/tresure/items/club_2.PNG",CardType.Item,GameState.StartTurn
                ,CardUsage.Self,BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Any,400,3,false)},
            {"boots",new ItemParams("boots", GenerateId(),@"/cards/tresure/items/boots.PNG",CardType.Item,GameState.StartTurn
                ,CardUsage.Self,BodyPartsEnum.Foot,1,ClassEnum.Any,RaceEnum.Any,400,2,false)},
        /// lvl
            {"ant",new CardParams("ant", GenerateId(),@"/cards/tresure/lvl/ant.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},

        /// enemy
            {"bigfoot",new EnemyParams("bigfoot",GenerateId(),@"/cards/doors/enemy/bigfoot.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                12,0,3,new LostItemFunction(BodyPartsEnum.Head).LostItem,new RaceClassBuff(3,ClassEnum.None,RaceEnum.Dwarf|RaceEnum.Halfling).GetBuff)}
        };
        public static CardParams GetCard(string name)
        {
            Console.WriteLine(name+"card");
            return cardsParams[name];
        }
        public static bool SetCard(string name,CardParams cardParams)
        {            
            return cardsParams.TryAdd(name,cardParams);
        }
        private static int maxID;
        private static int GenerateId(){
            return maxID++;
        }
    }
   
}