using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Exeptions;
using System.Linq;
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
        protected Dictionary<PlayerProfile,int> lostFunctDone;
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
        public bool Finish(PlayerProfile pp,bool fromLostFunc)
        {
            var lost = true;
            var ppIndex = players.IndexOf(pp);
            if(ppIndex==-1) throw new IndexOutOfRangeException();
            if(!fromLostFunc)
            {
                for(int i=0;i<enemies.Count;i++)
                {
                    var wasoutFuncRes = enemies[i].WasOut(pp);
                    if(wasoutFuncRes != GameParams.NoneWashOut)
                        if(rolls[ppIndex,i]+rollsBuff[ppIndex,i]+enemies[i].WasOut(pp) >= toWin)
                        {//win
                            lost = false;
                        } else {//lost
                        
                            if(lostFunctDone == null)
                                lostFunctDone = new Dictionary<PlayerProfile, int>(){};
                    
                            if(!lostFunctDone.ContainsKey(pp))
                            {
                                lostFunctDone.Add(pp,0);
                            }
                            if(enemies[i].LostFunction(pp))
                            {
                                lostFunctDone[pp] += 1;
                            }
                        }                
                }
            } else { lostFunctDone[pp] += 1;}

            Console.WriteLine(lostFunctDone[pp]+"enemy count");
            if(lost & lostFunctDone[pp] == enemies.Count)
                return AfterFinish(pp);
            return false;

        }
        public bool AfterFinish(PlayerProfile pp)
        {
            var ppIndex = players.IndexOf(pp);
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
                if(enemies.Count > 1) throw new DefautlMesageException("enemy can`t be null if elemiew>1"); /// exception
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
                    var enemybaff = enemies[j].WasOut(players[playerIndex]);
                    if(enemybaff == GameParams.NoneWashOut)
                    {
                         temp+= "\n"+enemies[j].Name + "тебя не трогает";
                    }else
                    {
                        var tempwashout = enemies[j].WasOut(players[playerIndex]);
                        var endroll = rolls[playerIndex,j]+tempwashout;
                        var win = endroll >= toWin ? "win":"lost";
                        temp+= "\n"+enemies[j].Name + " ролл : "+rolls[playerIndex,j]+ "+баф капрты "+ tempwashout+" "+ win; 
                    }
                        
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