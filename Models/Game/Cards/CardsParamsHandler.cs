using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Helpers;
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
                12,1,3,new LostItemFunction(BodyPartsEnum.Head).LostItem,
                    new DefaulBuff(3,new IsRaceHelper(RaceEnum.Dwarf|RaceEnum.Halfling).IsRace).GetBuff,new LvlWashOut().WashOut)},
            
            {"bull",new EnemyParams("bull",GenerateId(),@"/cards/doors/enemy/bull.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                18,2,5,new DethLostFunction().Deth,new NoneFightBuff().GetBuff,new LvlWashOut(4).WashOut)},
            
            {"dice",new EnemyParams("dice",GenerateId(),@"/cards/doors/enemy/dice.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                2,1,1,new LostItemFunction(BodyPartsEnum.Any,true,-1).LostItem,new NoneFightBuff().GetBuff,new DefaultWashOut(null,1).WashOut)},

            {"duck_monster",new EnemyParams("duck_monster",GenerateId(),@"/cards/doors/enemy/duck_monster.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                6,1,2,new ChouseLostFunction(new Dictionary<string, Func<Player.PlayerProfile,bool>>(){
                    {"потерять карты",new LostHandCardFunction(-1).LostItem},
                    {"потерять уровни",new LostLevelFunction(2,(Player.PlayerProfile pp)=>{return true;}).LostLevel}
                }).Chouse,new RaceClassBuff(6,ClassEnum.Wizard,RaceEnum.Any).GetBuff,new NoneWashOut().WashOut)},
            
            {"elder_dragon",new EnemyParams("elder_dragon",GenerateId(),@"/cards/doors/enemy/elder_dragon.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                20,2,5,new DethLostFunction().Deth,new NoneFightBuff().GetBuff,new LvlWashOut(5,0).WashOut)},
           
            {"cochlea",new EnemyParams("cochlea",GenerateId(),@"/cards/doors/enemy/cochlea.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                4,1,2,new ChouseLostFunction(new Dictionary<string, Func<Player.PlayerProfile, bool>>(){
                    {"потерять карты",new LostItemFunction(1).LostItem},
                    {"потерять уровни" , new LostLevelFunction(1,(Player.PlayerProfile pp)=>{return true;}).LostLevel}}).Chouse
                ,new NoneFightBuff().GetBuff,new DefaultWashOut(null,-2).WashOut)}, //todo dise roll lost
           
            {"dog",new EnemyParams("dog",GenerateId(),@"/cards/doors/enemy/dog.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                2,1,1,new LostLevelFunction(2,(Player.PlayerProfile pp)=>{return true;}).LostLevel,
                new NoneFightBuff().GetBuff,new NoneWashOut().WashOut)}, //todo throw item win
            
            {"drank_golem",new EnemyParams("drank_golem",GenerateId(),@"/cards/doors/enemy/drank_golem.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                14,1,4,new DethLostFunction().Deth,new NoneFightBuff().GetBuff,new DefaultWashOut(new IsRaceHelper(RaceEnum.Halfling).IsRace,GameParams.NoneWashOut).WashOut)},
            
            {"face",new EnemyParams("face",GenerateId(),@"/cards/doors/enemy/face.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                8,1,2,new ListLostFunction(new List<Func<Player.PlayerProfile,bool>>(){
                    new LostLevelFunction(1,(Player.PlayerProfile pp)=>{return true;}).LostLevel,
                    new LostItemFunction(BodyPartsEnum.Head,-1).LostItem}).LostFuncs,
                new DefaulBuff(6,new IsRaceHelper(RaceEnum.Elf).IsRace).GetBuff,new NoneWashOut().WashOut)},

            {"fear",new EnemyParams("fear",GenerateId(),@"/cards/doors/enemy/fear.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                14,1,4,new DethLostFunction(new IsClassHelper(ClassEnum.Wizard).IsClass,(Player.PlayerProfile pp)=>{
                    pp.DropClass(ClassEnum.Wizard);
                    return true;
                }).Deth,new DefaulBuff(4,new IsClassHelper(ClassEnum.Warior).IsClass).GetBuff,new NoneWashOut().WashOut)},
            {"frogs",new EnemyParams("frogs",GenerateId(),@"/cards/doors/enemy/frogs.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                2,1,1,new LostLevelFunction(2).LostLevel,new NoneFightBuff().GetBuff,new DefaultWashOut(null,-1).WashOut)},
            {"girls",new EnemyParams("girls",GenerateId(),@"/cards/doors/enemy/girls.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                8,1,2,new EquateLevelFunction().LostLevel,new NoneItemsFightBuff().GetBuff,new NoneWashOut().WashOut)},
            {"gish",new EnemyParams("gish",GenerateId(),@"/cards/doors/enemy/gish.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new OtherwiseLostFunction(new LostItemFunction(BodyPartsEnum.Foot).LostItem,new LostLevelFunction(1).LostLevel,(Player.PlayerProfile pp)=>{
                return pp.GetItems(BodyPartsEnum.Foot).Count !=1;}).Lost,new DefaulBuff(4,new IsRaceHelper(RaceEnum.Elf).IsRace).GetBuff,new NoneWashOut().WashOut)},
            {"goblin",new EnemyParams("goblin",GenerateId(),@"/cards/doors/enemy/goblin.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new LostLevelFunction(1).LostLevel,new NoneFightBuff().GetBuff,new DefaultWashOut(null,1).WashOut)},
            {"grass",new EnemyParams("grass",GenerateId(),@"/cards/doors/enemy/grass.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new NoneLostFunction().LostLevel,new DefaulBuff(0,(Player.PlayerProfile pp)=>{
                    if(pp.isRace(RaceEnum.Elf)) pp.game.PlayerTakeCard(pp,CardType.Tresure,false);
                    return true;
                }).LostLevel,new NoneWashOut().WashOut)},
            {"griffin",new EnemyParams("griffin",GenerateId(),@"/cards/doors/enemy/griffin.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                16,2,4,new NoneLostFunction().LostLevel,new NoneFightBuff().buff,new LvlWashOut(3,0).WashOut)},//todo lostfunc
            {"harpy",new EnemyParams("harpy",GenerateId(),@"/cards/doors/enemy/harpy.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                4,1,2,new LostLevelFunction(2).LostLevel,new NoneFightBuff().buff,new LvlWashOut(3,0).WashOut)},
        //todo badEffect
        /// enemyBuff
            {"brain", new EnemyBuffParams("brain",GenerateId(),@"/cards/doors/buff/brain.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,5,0,1)},
            {"bigone", new EnemyBuffParams("bigone",GenerateId(),@"/cards/doors/buff/bigone.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,10,0,2)},
            {"child", new EnemyBuffParams("child",GenerateId(),@"/cards/doors/buff/child.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,-5,0,-1)},
            {"crazy", new EnemyBuffParams("crazy",GenerateId(),@"/cards/doors/buff/crazy.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,5,0,1)},
        };
        public static CardParams GetCard(string name)
        {
            Console.WriteLine(name+"card");
            return cardsParams[name];
        }
        public static List<CardParams> GetAllCards()
        {
            var cards = new List<CardParams>();
            foreach(var item in cardsParams)
                cards.Add(item.Value);
            return cards;
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