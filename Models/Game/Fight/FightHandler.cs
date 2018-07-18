using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Fight
{
    public class FightHendler
    {
        protected Game thisGame;
        protected PlayerProfile fightPlayer;
        protected PlayerProfile helperPlayer;
        protected EnemyCard enemy;
        protected List<EnemyCard> ExtraEnemy = new  List<EnemyCard>();
        protected Dictionary<PlayerProfile,bool> ReadyPlayers = new Dictionary<PlayerProfile, bool>();
        protected int extraBuff;


        public FightHendler(Game g,PlayerProfile pp,List<PlayerProfile> minorPLayers)
        {
            thisGame = g;
            fightPlayer = pp;
            fightPlayer.PlayerState = PlayerState.Fight;
            foreach (var player in minorPLayers)
            {
                ReadyPlayers.Add(player,false);
            }
        }
        public void SetMonster(EnemyCard ec){enemy = ec;}
        public void SetHelper(PlayerProfile pp)
        {
            this.helperPlayer = pp;
            ReadyPlayers.Remove(pp);
            pp.PlayerState = PlayerState.Fight;
        }
        public string Count(){ 
            var message = "";
            var enemyDmg = EnemyDmg();
            var mainDmg = PlayerDamage(fightPlayer);
            var helpDmg=0;
            message += "@"+fightPlayer.UserName + " статы " + mainDmg;

            if(helperPlayer != null)
            {
                helpDmg = PlayerDamage(helperPlayer);
                message+= "\n@"+helperPlayer.UserName+ " статы " + helpDmg;
            }
            if(helpDmg ==0)
                message+= "\nдополнительные статы " + helpDmg;
            message+= "\n\nстаты врагов" + enemyDmg;
            return message;
        }
        public bool Finish(){
            foreach (var player in ReadyPlayers)
            {
               if(player.Value == false){
                   throw new DefautlMesageException("Не все игроки готовы");
                }  
            }
            var enemyDmg = EnemyDmg();
            var mainDmg = PlayerDamage(fightPlayer);
            var helpDmg=0;
            if(helperPlayer != null)
            {
                helpDmg = PlayerDamage(helperPlayer);
            }
            if(mainDmg+helpDmg+extraBuff > enemyDmg)
            {
                return true; // win
            }
            return false; // lost
        }
        public void Win()
        {            
            var ishelperPlayer = helperPlayer != null ? true : false;
            fightPlayer.PlayerState = PlayerState.Charity;
            if(ishelperPlayer) 
                helperPlayer.PlayerState = PlayerState.Iddle;
            
            for(int i=0;i<enemy.WinLevelsCount;i++)
            {
                fightPlayer.LevelUp();
            }
            
            for(int i=0;i<enemy.WinTresureCount;i++)
            {
                thisGame.PlayerTakeCard(fightPlayer,Cards.CardType.Tresure,ishelperPlayer);
            }
        }
        public void Lost()
        {
            var pps = new List<PlayerProfile>();
            pps.Add(fightPlayer);
            if(helperPlayer!= null) pps.Add(helperPlayer);
            var enemyList = new List<EnemyCard>(){enemy};
            foreach (var enemy in ExtraEnemy)
            {
                enemyList.Add(enemy);
            }
            thisGame.StartWashOut(pps,enemyList);
        }
        public bool UseBuff(BuffCard buff)
        {
            if(enemy == null) throw new DefautlMesageException("");
            if(ExtraEnemy != null) throw new Exception("to do EnemyCard UseBuff");//todo if many enemy
            enemy.AddBuff(buff);
            return true;
        }
       
#region helpers
        private int EnemyDmg()
        {
            var isbuffed = false;

            var enemyDmg = enemy.Level;
            var buff = enemy.FightBuff(fightPlayer);
            if(buff == 0 && helperPlayer != null)
            {
                buff = enemy.FightBuff(helperPlayer);
            }
            enemyDmg += buff;
            return enemyDmg;
        }
        protected int PlayerDamage(PlayerProfile pp)
        {
           return pp.getDmg();
        }
#endregion
    }
}