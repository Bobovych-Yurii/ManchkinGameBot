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
        /// race
            {"dwarf_2",new RaceParams("dwarf_2", GenerateId(),@"/cards/tresure/class/dwarf_2.PNG",RaceEnum.Dwarf)},
            {"dwarf_3",new RaceParams("dwarf_3", GenerateId(),@"/cards/tresure/class/dwarf_3.PNG",RaceEnum.Dwarf)},
            {"dwarf_class",new RaceParams("dwarf_class", GenerateId(),@"/cards/tresure/class/dwarf_class.PNG",RaceEnum.Dwarf)},

            {"elf_2",new RaceParams("elf_2", GenerateId(),@"/cards/tresure/class/elf_2.PNG",RaceEnum.Elf)},
            {"elf_3",new RaceParams("elf_3", GenerateId(),@"/cards/tresure/class/elf_3.PNG",RaceEnum.Elf)},
            {"elf_class",new RaceParams("elf_class", GenerateId(),@"/cards/tresure/class/elf_class.PNG",RaceEnum.Elf)},

            {"hafling_class",new RaceParams("elf_class", GenerateId(),@"/cards/tresure/class/elf_class.PNG",RaceEnum.Halfling)},
            {"hafling_class_2",new RaceParams("elf_class", GenerateId(),@"/cards/tresure/class/elf_class.PNG",RaceEnum.Halfling)},
            {"hafling_class_3",new RaceParams("elf_class", GenerateId(),@"/cards/tresure/class/elf_class.PNG",RaceEnum.Halfling)},

            {"racial_cocktail",new RaceParams("racial_cocktail", GenerateId(),@"/cards/tresure/class/racial_cocktail.PNG",RaceEnum.Cocktail)},
            {"racial_cocktail_2",new RaceParams("racial_cocktail_2", GenerateId(),@"/cards/tresure/class/racial_cocktail_2.PNG",RaceEnum.Cocktail)},
        /// class
            {"cleric_class",new ClassParams("cleric_class", GenerateId(),@"/cards/tresure/class/cleric_class.PNG",ClassEnum.Clirick)},
            {"cleric_class_2",new ClassParams("cleric_class_2", GenerateId(),@"/cards/tresure/class/cleric_class_2.PNG",ClassEnum.Clirick)},            
            {"cleric_class_3",new ClassParams("cleric_class_3", GenerateId(),@"/cards/tresure/class/cleric_class_3.PNG",ClassEnum.Clirick)},

            {"roge_class",new ClassParams("roge_class", GenerateId(),@"/cards/tresure/class/roge_class.PNG",ClassEnum.Thief)},
            {"roge_class_2",new ClassParams("roge_class_2", GenerateId(),@"/cards/tresure/class/roge_class_2.PNG",ClassEnum.Thief)},
            {"thief_class",new ClassParams("thief_class", GenerateId(),@"/cards/tresure/class/thief_class.PNG",ClassEnum.Thief)},

            {"super_manchkin",new ClassParams("super_manchkin", GenerateId(),@"/cards/tresure/class/super_manchkin.PNG",ClassEnum.Super)},
            {"super_manchkin_2",new ClassParams("super_manchkin_2", GenerateId(),@"/cards/tresure/class/super_manchkin_2.PNG",ClassEnum.Super)},

            {"wanderer_3",new ClassParams("wanderer_3", GenerateId(),@"/cards/tresure/class/wanderer_3PNG",ClassEnum.Warior)},
            {"wanderer_4",new ClassParams("wanderer_4", GenerateId(),@"/cards/tresure/class/wanderer_4.PNG",ClassEnum.Warior)},
            {"war_class",new ClassParams("war_class", GenerateId(),@"/cards/tresure/class/war_class.PNG",ClassEnum.Warior)},

            {"wizard_class",new ClassParams("wizard_class", GenerateId(),@"/cards/tresure/class/wizard_class.PNG",ClassEnum.Wizard)},
            {"wizard_class_2",new ClassParams("wizard_class_2", GenerateId(),@"/cards/tresure/class/wizard_class_2.PNG",ClassEnum.Wizard)},
            {"wizard_class_3",new ClassParams("wizard_class_3", GenerateId(),@"/cards/tresure/class/wizard_class_3.PNG",ClassEnum.Wizard)},

        /// items    
            {"archer",new ItemParams("archer",GenerateId(),@"/cards/tresure/items/archer.PNG",
                BodyPartsEnum.Hand,2,ClassEnum.Any,RaceEnum.Elf,800,4,false)},
            {"armor",new ItemParams("armor", GenerateId(),@"/cards/tresure/items/armor.PNG",
                BodyPartsEnum.Chest,1,ClassEnum.Any,RaceEnum.Dwarf,400,3,false)},
            {"backet",new ItemParams("backet",GenerateId(),@"/cards/tresure/items/backet.PNG",
                BodyPartsEnum.Head,1,ClassEnum.Any,RaceEnum.Any,200,1,false)},
            {"club_2",new ItemParams("club_2", GenerateId(),@"/cards/tresure/items/club_2.PNG",
                BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Any,400,3,false)},
            {"boots",new ItemParams("boots", GenerateId(),@"/cards/tresure/items/boots.PNG",
                BodyPartsEnum.Foot,1,ClassEnum.Any,RaceEnum.Any,400,2,false)},

            {"buckler",new ItemParams("buckler", GenerateId(),@"/cards/tresure/items/buckler.PNG",
                BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Any,400,2,false)},
            {"buff_2",new ItemParams("buff_2", GenerateId(),@"/cards/tresure/items/buff_2.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Any,300,0,true,1)},
            {"buff_3",new ItemParams("buff_3", GenerateId(),@"/cards/tresure/items/buff_3.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Clirick,RaceEnum.Any,400,2,false)},
            {"burn_armor",new ItemParams("burn_armor", GenerateId(),@"/cards/tresure/items/burn_armor.PNG"
                ,BodyPartsEnum.Chest,1,ClassEnum.Any,RaceEnum.Any,400,2,false)},
            {"club",new ItemParams("club", GenerateId(),@"/cards/tresure/items/club.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Clirick,RaceEnum.Any,600,4,false)},
            {"cue",new ItemParams("cue", GenerateId(),@"/cards/tresure/items/cue.PNG"
                ,BodyPartsEnum.Hand,2,ClassEnum.Any,RaceEnum.Any,200,1,false)},
            {"foot",new ItemParams("foot", GenerateId(),@"/cards/tresure/items/foot.PNG"
                ,BodyPartsEnum.Foot,1,ClassEnum.Any,RaceEnum.Any,400,0,false,2)},
            {"gish_armor",new ItemParams("gish_armor", GenerateId(),@"/cards/tresure/items/gish_armor.PNG"
                ,BodyPartsEnum.Chest,1,ClassEnum.Any,RaceEnum.Any,200,2,false)},
            {"hammer",new ItemParams("hammer", GenerateId(),@"/cards/tresure/items/hammer.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Dwarf,600,4,false)},
            {"hat",new ItemParams("hat", GenerateId(),@"/cards/tresure/items/hat.PNG"
                ,BodyPartsEnum.Head,1,ClassEnum.Wizard,RaceEnum.Any,400,3,false)},
            {"helebird",new ItemParams("helebird", GenerateId(),@"/cards/tresure/items/helebird.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Humman,600,4,true)},
            {"knifes",new ItemParams("knifes", GenerateId(),@"/cards/tresure/items/knifes.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Thief,RaceEnum.Any,400,3,false)},
            {"mifril",new ItemParams("mifril", GenerateId(),@"/cards/tresure/items/mifril.PNG"
                ,BodyPartsEnum.Chest,1,ClassEnum.Any|ClassEnum.Wizard,RaceEnum.Any,600,3,true)}, //todo check
            {"nofear",new ItemParams("nofear", GenerateId(),@"/cards/tresure/items/nofear.PNG"
                ,BodyPartsEnum.Head,1,ClassEnum.Any,RaceEnum.Humman,400,3,false)},
            {"rapier",new ItemParams("rapier", GenerateId(),@"/cards/tresure/items/rapier.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Elf,600,3,false)},
            {"shild",new ItemParams("shild", GenerateId(),@"/cards/tresure/items/shild.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Wizard,RaceEnum.Any,600,4,true)},
            {"stone",new ItemParams("stone", GenerateId(),@"/cards/tresure/items/stone.PNG"
                ,BodyPartsEnum.Hand,2,ClassEnum.Any,RaceEnum.Any,0,3,true)},
            {"suit",new ItemParams("suit", GenerateId(),@"/cards/tresure/items/suit.PNG"
                ,BodyPartsEnum.Chest,1,ClassEnum.Any,RaceEnum.Any,1,200,false)},
            {"weapon",new ItemParams("weapon", GenerateId(),@"/cards/tresure/items/weapon.PNG"
                ,BodyPartsEnum.Hand,2,ClassEnum.Any,RaceEnum.Any,3,600,true)},
            {"wizard_attack",new ItemParams("wizard_attack", GenerateId(),@"/cards/tresure/items/wizard_attack.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Wizard,RaceEnum.Any,3,600,false)},
            
            {"blade",new ItemParams("blade", GenerateId(),@"/cards/tresure/items/blade.PNG"
                ,BodyPartsEnum.Hand,1,ClassEnum.Any,RaceEnum.Any,2,400,false)},
            

            
        /// lvl
            {"ant",new CardParams("ant", GenerateId(),@"/cards/tresure/lvl/ant.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            {"corps",new CardParams("corps", GenerateId(),@"/cards/tresure/lvl/corps.PNG",CardType.LevelUp,GameState.Charity,CardUsage.Self)},
            {"master_2",new CardParams("master_2", GenerateId(),@"/cards/tresure/lvl/master_2.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            {"master_3",new CardParams("master_3", GenerateId(),@"/cards/tresure/lvl/master_3.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            {"mercenary",new CardParams("mercenary", GenerateId(),@"/cards/tresure/lvl/mercenary.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)}, //todo 
            {"new_level",new CardParams("new_level", GenerateId(),@"/cards/tresure/lvl/new_level.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            {"porion",new CardParams("porion", GenerateId(),@"/cards/tresure/lvl/porion.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            {"lvl_up",new CardParams("lvl_up", GenerateId(),@"/cards/tresure/lvl/lvl_up.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            {"master",new CardParams("master", GenerateId(),@"/cards/tresure/lvl/master.PNG",CardType.LevelUp,GameState.Play,CardUsage.Self)},
            

        /// enemy
            {"bigfoot",new EnemyParams("bigfoot",GenerateId(),@"/cards/doors/enemy/bigfoot.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                12,1,3,new LostItemFunction(BodyPartsEnum.Head).LostItem,
                    new DefaulBuff(3,new IsRaceHelper(RaceEnum.Dwarf|RaceEnum.Halfling).IsRace).GetBuff,new LvlWashOut().WashOut)},
            
            {"bull",new EnemyParams("bull",GenerateId(),@"/cards/doors/enemy/bull.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                18,2,5,new DethLostFunction().Deth,new NoneFightBuff().GetBuff,new LvlWashOut(4).WashOut)},
            
            {"dice",new EnemyParams("dice",GenerateId(),@"/cards/doors/enemy/dice.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                2,1,1,new LostItemFunction(BodyPartsEnum.Any,true,-1).LostItem,new NoneFightBuff().GetBuff,new DefaultWashOut(1,null).WashOut)},

            {"duck_monster",new EnemyParams("duck_monster",GenerateId(),@"/cards/doors/enemy/duck_monster.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                6,1,2,new ChouseLostFunction(new Dictionary<string, Func<Player.PlayerProfile,bool>>(){
                    {"потерять карты",new LostHandCardFunction(-1).LostHand},
                    {"потерять уровни",new LostLevelFunction(2,(Player.PlayerProfile pp)=>{return true;}).LostLevel}
                }).Chouse,new RaceClassBuff(6,ClassEnum.Wizard,RaceEnum.Any).GetBuff,new NoneWashOut().WashOut)},
            
            {"elder_dragon",new EnemyParams("elder_dragon",GenerateId(),@"/cards/doors/enemy/elder_dragon.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                20,2,5,new DethLostFunction().Deth,new NoneFightBuff().GetBuff,new LvlWashOut(5,0).WashOut)},
           
            {"cochlea",new EnemyParams("cochlea",GenerateId(),@"/cards/doors/enemy/cochlea.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                4,1,2,new ChouseLostFunction(new Dictionary<string, Func<Player.PlayerProfile, bool>>(){
                    {"потерять карты",new LostItemFunction(1).LostItem},
                    {"потерять уровни" , new LostLevelFunction(1,(Player.PlayerProfile pp)=>{return true;}).LostLevel}}).Chouse
                ,new NoneFightBuff().GetBuff,new DefaultWashOut(-2,null).WashOut)}, //todo dise roll lost
           
            {"dog",new EnemyParams("dog",GenerateId(),@"/cards/doors/enemy/dog.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                2,1,1,new LostLevelFunction(2,(Player.PlayerProfile pp)=>{return true;}).LostLevel,
                new NoneFightBuff().GetBuff,new NoneWashOut().WashOut)}, //todo throw item win
            
            {"drank_golem",new EnemyParams("drank_golem",GenerateId(),@"/cards/doors/enemy/drank_golem.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                14,1,4,new DethLostFunction().Deth,new NoneFightBuff().GetBuff,new DefaultWashOut(GameParams.NoneWashOut,new IsRaceHelper(RaceEnum.Halfling).IsRace).WashOut)},
            
            {"face",new EnemyParams("face",GenerateId(),@"/cards/doors/enemy/face.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                8,1,2,new ListLostFunction(new List<Func<Player.PlayerProfile,bool>>(){
                    new LostLevelFunction(1,(Player.PlayerProfile pp)=>{return true;}).LostLevel,
                    new LostItemFunction(BodyPartsEnum.Head,-1).LostItem}).LostFuncs,
                new DefaulBuff(6,new IsRaceHelper(RaceEnum.Elf).IsRace).GetBuff,new NoneWashOut().WashOut)},

            {"fear",new EnemyParams("fear",GenerateId(),@"/cards/doors/enemy/fear.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                14,1,4,new DethLostFunction(new IsClassHelper(ClassEnum.Wizard).IsClass,(Player.PlayerProfile pp)=>{
                    pp.LostClass();
                    return true;
                }).Deth,new DefaulBuff(4,new IsClassHelper(ClassEnum.Warior).IsClass).GetBuff,new NoneWashOut().WashOut)},
            {"frogs",new EnemyParams("frogs",GenerateId(),@"/cards/doors/enemy/frogs.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                2,1,1,new LostLevelFunction(2).LostLevel,new NoneFightBuff().GetBuff,new DefaultWashOut(-1,null).WashOut)},
            {"girls",new EnemyParams("girls",GenerateId(),@"/cards/doors/enemy/girls.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                8,1,2,new EquateLevelFunction().LostLevel,new NoneItemsFightBuff().GetBuff,new NoneWashOut().WashOut)},
            {"gish",new EnemyParams("gish",GenerateId(),@"/cards/doors/enemy/gish.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new OtherwiseLostFunction(new LostItemFunction(BodyPartsEnum.Foot).LostItem,new LostLevelFunction(1).LostLevel,(Player.PlayerProfile pp)=>{
                return pp.GetItems(BodyPartsEnum.Foot).Count !=1;}).Lost,new DefaulBuff(4,new IsRaceHelper(RaceEnum.Elf).IsRace).GetBuff,new NoneWashOut().WashOut)},
            {"goblin",new EnemyParams("goblin",GenerateId(),@"/cards/doors/enemy/goblin.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new LostLevelFunction(1).LostLevel,new NoneFightBuff().GetBuff,new DefaultWashOut(1,null).WashOut)},
            {"grass",new EnemyParams("grass",GenerateId(),@"/cards/doors/enemy/grass.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new NoneLostFunction().None,new DefaulBuff(0,(Player.PlayerProfile pp)=>{
                    if(pp.isRace(RaceEnum.Elf)) pp.game.PlayerTakeCard(pp,CardType.Tresure,false);
                    return true;
                }).GetBuff,new NoneWashOut().WashOut)},
            {"griffin",new EnemyParams("griffin",GenerateId(),@"/cards/doors/enemy/griffin.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                16,2,4,new NoneLostFunction().None,new NoneFightBuff().GetBuff,new LvlWashOut(3,0).WashOut)},//todo lostfunc
            {"harpy",new EnemyParams("harpy",GenerateId(),@"/cards/doors/enemy/harpy.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                4,1,2,new LostLevelFunction(2).LostLevel,new DefaulBuff(5,new IsClassHelper(ClassEnum.Wizard).IsClass).GetBuff,new NoneWashOut().WashOut)},
            {"horse",new EnemyParams("horse",GenerateId(),@"/cards/doors/enemy/horse.PNG",CardType.Undead,GameState.LookTrable|GameState.Fight,CardUsage.Enemy,
                4,1,2,new LostLevelFunction(2).LostLevel,new DefaulBuff(5,new IsRaceHelper(RaceEnum.Dwarf).IsRace).GetBuff,new NoneWashOut().WashOut)},
            {"legion",new EnemyParams("legion",GenerateId(),@"/cards/doors/enemy/legion.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                10,1,3,new RollLostFunction((Player.PlayerProfile pp,int roll)=>{
                    if(roll<3){
                        new DethLostFunction().Deth(pp);
                    } else{
                        pp.LostLevel(roll);
                    }
                    return true;
                }).Roll,new DefaulBuff(6,new IsRaceHelper(RaceEnum.Dwarf).IsRace).GetBuff,new NoneWashOut().WashOut)},
            {"leprechaun",new EnemyParams("leprechaun",GenerateId(),@"/cards/doors/enemy/leprechaun.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                4,1,2,new LostItemFunction(2).LostItem,new DefaulBuff(5,new IsRaceHelper(RaceEnum.Elf).IsRace).GetBuff,new NoneWashOut().WashOut)},//todo frendsChouse
            {"monster_1",new EnemyParams("monster_1",GenerateId(),@"/cards/doors/enemy/monster_1.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                6,1,2,new LostHandCardFunction(-1).LostHand,new NoneFightBuff().GetBuff,new NoneWashOut().WashOut)},//todo extra win func
            {"mosquitoes",new EnemyParams("mosquitoes",GenerateId(),@"/cards/doors/enemy/mosquitoes.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,2,new LostItemFunction(BodyPartsEnum.Chest|BodyPartsEnum.Foot).LostItem,new NoneFightBuff().GetBuff,new DefaultWashOut(GameParams.NoneWashOut).WashOut)},
            {"nerd",new EnemyParams("nerd",GenerateId(),@"/cards/doors/enemy/nerd.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                6,1,2,new LostClassRaceFunction(true,true).Lost,new DefaulBuff(6,new IsClassHelper(ClassEnum.Warior).IsClass).GetBuff,new NoneWashOut().WashOut)},
            {"octo",new EnemyParams("octo",GenerateId(),@"/cards/doors/enemyocto.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                19,2,4,new DethLostFunction().Deth,new DefaulBuff(4,new IsRaceHelper(RaceEnum.Elf).IsRace).GetBuff,
                new DefaultWashOut(GameParams.NoneWashOut,new IsRaceHelper(RaceEnum.Dwarf|RaceEnum.Halfling|RaceEnum.Humman).IsRace).WashOut)},//todo bycard
            {"rat",new EnemyParams("rat",GenerateId(),@"/cards/doors/enemy/rat.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                1,1,1,new LostLevelFunction(1).LostLevel,new DefaulBuff(3,new IsClassHelper(ClassEnum.Clirick).IsClass).GetBuff,new NoneWashOut().WashOut)},
            {"shelter",new EnemyParams("shelter",GenerateId(),@"/cards/doors/enemy/shelter.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                8,1,2,new LostLevelFunction(3).LostLevel,new DefaulBuff(GameParams.NoItemsFightBuff,(Player.PlayerProfile pp)=>{ return true;}).GetBuff,new NoneWashOut().WashOut)},
            {"vampire",new EnemyParams("vampire",GenerateId(),@"/cards/doors/enemy/vampire.PNG",CardType.Enemy,GameState.LookTrable,CardUsage.Enemy,
                12,1,3,new LostLevelFunction(3).LostLevel,new DefaulBuff(GameParams.InstaWinFightBuff,new IsClassHelper(ClassEnum.Clirick).IsClass).GetBuff,new NoneWashOut().WashOut)},
            
                

        //todo badEffect
        /// enemyBuff
            {"brain", new EnemyBuffParams("brain",GenerateId(),@"/cards/doors/buff/brain.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,5,0,1)},
            {"bigone", new EnemyBuffParams("bigone",GenerateId(),@"/cards/doors/buff/bigone.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,10,0,2)},
            {"child", new EnemyBuffParams("child",GenerateId(),@"/cards/doors/buff/child.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,-5,0,-1)},
            {"crazy", new EnemyBuffParams("crazy",GenerateId(),@"/cards/doors/buff/crazy.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,5,0,1)},
            {"oldone", new EnemyBuffParams("oldone",GenerateId(),@"/cards/doors/buff/oldone.PNG",CardType.Buff,GameState.Fight,CardUsage.Enemy,10,0,2)},
        };
        public static CardParams GetCard(string name)
        {
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