using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Fight
{
    public class WashOutHandler
    {
        private const int toWin = 5;
        protected Game thisGame;
        protected List<PlayerProfile> players;
        protected List<EnemyCard> enemies;
        protected int[,] rolls;
        protected int[,] rollsBuff; 
        protected bool[] finish;
        public WashOutHandler(Game g,List<PlayerProfile> pps,List<EnemyCard> enemiesList)
        {
            thisGame = g;
            players = pps;
            enemies = enemiesList;
            rolls = new int[players.Count,enemies.Count];
            rollsBuff = new int[players.Count,enemies.Count];
            finish = new bool[players.Count];
            
            foreach (var pp in pps)
            {
                foreach (var enemy in enemiesList)
                {
                    Roll(pp,enemy);
                }
            }
        }
        public bool Finish(PlayerProfile pp)
        {
            var ppIndex = players.IndexOf(pp);
            if(ppIndex==-1) throw new IndexOutOfRangeException();
            for(int i=0;i<enemies.Count;i++)
            {
                if(rolls[ppIndex,i]+rollsBuff[ppIndex,i] >= toWin)
                {//win
                
                } else {//lost
                   enemies[i].LostFunction(pp);
                }                
            }
            pp.PlayerState = PlayerState.Charity;
            finish[ppIndex] = true;
            foreach(var temp in finish)
            {
                if(temp == false) return false;
            }
            return true;

        }
       public void Roll(PlayerProfile pp,EnemyCard enemy=null,int preRoll = -1)
       {
            var ppIndex = players.IndexOf(pp);
            if(ppIndex == -1) throw new IndexOutOfRangeException();
            if(enemy == null)
            {
                if(enemies.Count > 1) throw new Exception("enemy can`t be null if elemiew>1");
                InRoll(ppIndex,0,preRoll);
            } else {
                var enemyIndex = enemies.IndexOf(enemy);
                if(enemyIndex == -1) throw new IndexOutOfRangeException();
                InRoll(ppIndex,enemyIndex,preRoll);
            }
       }
       public void AddBuff(PlayerProfile pp, EnemyCard enemy=null,int buff=1)
       {
           var ppIndex = players.IndexOf(pp);
           var enemyIndex = -1;
           if(enemy == null)
           {
               if(enemies.Count >1) throw new IndexOutOfRangeException();
               enemyIndex = 0;
           } else
           {
               enemyIndex = enemies.IndexOf(enemy);
           }
           if(enemyIndex==-1 || ppIndex == -1) throw new IndexOutOfRangeException();

            rollsBuff[ppIndex,enemyIndex] += buff;
       }
       public string GetMessage(PlayerProfile pp=null)
       {
           string temp ="";
           if(pp==null)
           {
               for(int i=0;i<players.Count;i++)
               {
                    temp += "@"+players[i].UserName+GetEnemyString(i);
                      
               }
           } else {
                var playerIndex = players.IndexOf(pp);
                if(playerIndex == -1) throw new IndexOutOfRangeException();
                temp += "@"+pp.UserName+GetEnemyString(playerIndex);
               
           }
           return temp;
        }
        private string GetEnemyString(int playerIndex)
        {
            var temp = "";
            for(int j=0;j<enemies.Count;j++)
                {
                    var win = rolls[playerIndex,j] >= toWin ? "win":"lost";
                    temp+= "\n"+enemies[j].Name + " ролл : "+rolls[playerIndex,j]+ " " + win;     
                } 
            return temp;
        }
       private void InRoll(int playerIndex,int enemyIndex,int preRoll)
       {
            if(preRoll == -1)
                {
                    var roll = Dise.Roll();
                    rolls[playerIndex, enemyIndex] = roll;
                } else {
                     rolls[playerIndex, enemyIndex] = preRoll;
                }
       }
    }
}