using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Models.Game.Cards.Tresure;
using System.Linq;
namespace ManchkinGameApi.Models.Game.Cards
{
    public class CardsList
    {
        private static List<Card> cardsList = new List<Card>();
        static CardsList()
        {
            
            addTresure();
            addDoors();
        }
        public static List<Card> GetCards(){ return cardsList.ToList();}
        public static Card GetCard(int id){ return cardsList.Find(c=>c.Id == id);}
#region setupCards  
        private static void addDoors(){       
            addEnemy();   
            addEnemyBuff();  
        }
        private static void addEnemyBuff()
        {
            cardsList.AddRange(new List<Card>(){
                new EnemyBuffCard("brain"),
                new EnemyBuffCard("bigone"),
                new EnemyBuffCard("child"),
                new EnemyBuffCard("crazy"),
                new EnemyBuffCard("oldone"),
                });
        }
        private static void addEnemy(){
            cardsList.AddRange(new List<Card>(){
                new EnemyCard("duck_monster"),
                new EnemyCard("dice"),
                new EnemyCard("bigfoot"),
                new EnemyCard("bull"), 
                new EnemyCard("elder_dragon"),
                new EnemyCard("cochlea"),
                new EnemyCard("dog"),
                new EnemyCard("drank_golem"),
                new EnemyCard("face"),
                new EnemyCard("fear"),
                new EnemyCard("frogs"),
                new EnemyCard("girls"),
                new EnemyCard("gish"),
                new EnemyCard("goblin"),
                new EnemyCard("grass"),
                new EnemyCard("griffin"),
                new EnemyCard("harpy"),
                new EnemyCard("horse"),
                new EnemyCard("legion"),
                new EnemyCard("leprechaun"),
                new EnemyCard("monster_1"),
                new EnemyCard("mosquitoes"),
                new EnemyCard("nerd"),
                new EnemyCard("octo"),
                new EnemyCard("rat"),
                new EnemyCard("shelter"),
                new EnemyCard("vampire"),
                });
        }
        private static void addTresure()
        {
            
            addLvlUp();
            addItems();
            addClass();
            addRace();            
        }
        private static void addRace()
        {
            cardsList.AddRange(new List<Card>()
            {
                new RaceCard("dwarf_2"),new RaceCard("dwarf_3"),new RaceCard("dwarf_class"),
                new RaceCard("elf_2"),new RaceCard("elf_3"),new RaceCard("elf_class"),
                new RaceCard("hafling_class"),new RaceCard("hafling_class_2"),new RaceCard("hafling_class_3"),
                new RaceCard("racial_cocktail"),new RaceCard("racial_cocktail_2")
            });
        }
        private static void addLvlUp()
        {
            cardsList.AddRange(new List<Card>()
            {new LevelUp("ant"),
            new LevelUp("corps"),
            new LevelUp("master_2"),
            new LevelUp("master_3"),
            new LevelUp("mercenary"),
            new LevelUp("new_level"),
            new LevelUp("porion"),
            new LevelUp("lvl_up"),
            new LevelUp("master")});

        }
        private static void addItems()
        {
            cardsList.AddRange(new List<Card>()
            {
                new ItemCard("archer"),new ItemCard("armor"),new Club_2(),new ItemCard("backet"), new ItemCard("boots"),
                new ItemCard("buckler"),new ItemCard("buff_2"),new ItemCard("buff_3"),new ItemCard("burn_armor"),
                new ItemCard("club"),new ItemCard("cue"),new ItemCard("foot"),new ItemCard("gish_armor"),new ItemCard("hammer"),
                new ItemCard("hat"),new ItemCard("helebird"),new ItemCard("knifes"),new ItemCard("mifril"),
                new ItemCard("nofear"),new ItemCard("rapier"),new ItemCard("shild"),new ItemCard("stone"),
                new ItemCard("suit"),new ItemCard("weapon"),new ItemCard("mifril"),new ItemCard("wizard_attack")
            });
        }
        private static void addClass()
        {
            cardsList.AddRange(new List<Card>()
            {
                new ClassCard("cleric_class"),new ClassCard("cleric_class_2"),new ClassCard("cleric_class_3"),
                new ClassCard("roge_class"),new ClassCard("roge_class_2"),new ClassCard("thief_class"),
                new ClassCard("super_manchkin"),new ClassCard("super_manchkin_2"),new ClassCard("wanderer_3"),new ClassCard("wanderer_4"),
                new ClassCard("war_class"),new ClassCard("wizard_class"),new ClassCard("wizard_class_2"),new ClassCard("wizard_class_3")
            });
        }
#endregion

        
        
    }
}