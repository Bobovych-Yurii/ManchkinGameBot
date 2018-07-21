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
                new EnemyBuffCard("crazy")
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
                });
        }
        private static void addTresure()
        {
            addLvlUp();
            addItems();
            addClass();            
        }
        private static void addLvlUp()
        {
            cardsList.AddRange(new List<Card>()
            {new LevelUp("ant")});
        }
        private static void addItems()
        {
            cardsList.AddRange(new List<Card>()
            {new ItemCard("archer"),new ItemCard("armor"),new Club_2(),new ItemCard("backet"), new ItemCard("boots")});
        }
        private static void addClass()
        {
            cardsList.AddRange(new List<Card>()
            {new Cleric("cleric_1"),new Cleric("cleric_2"),new Cleric("cleric_3")});
        }
#endregion

        
        
    }
}