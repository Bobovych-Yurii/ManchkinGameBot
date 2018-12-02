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
        private bool soloKill = false;
        private bool noFight = false;

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
        
        public void SetMonster(EnemyCard ec)
        {
            enemy = ec; 
        }
        public void SetHelper(PlayerProfile pp)
        {
            this.helperPlayer = pp;
            ReadyPlayers.Remove(pp);
            pp.PlayerState = PlayerState.Fight;
        }
        public string Count()
        { 
            var message = "";
            var enemyDmg = EnemyDmg();
            var mainDmg = PlayerDamage(fightPlayer);
            var helpDmg=0;
            message += "@"+fightPlayer.UserName + " статы " + mainDmg;
            if(helperPlayer != null && isFughtBuffConst(enemy,GameParams.NohelpFightBuff))
            {
                helpDmg = PlayerDamage(helperPlayer);
                message+= "\n@"+helperPlayer.UserName+ " статы " + helpDmg;
            }
            if(helpDmg ==0)
                message+= "\nдополнительные статы " + helpDmg;
            message+= "\n\nстаты врагов" + enemyDmg;
            return message;
        }
        public void PlayerReadyFight(PlayerProfile pp)
        {
            if(ReadyPlayers.ContainsKey(pp))
                ReadyPlayers[pp] = true;
        }
        public bool Finish(){
            if(isFughtBuffConst(enemy,GameParams.InstaWinFightBuff))
            {
                return true;
            } 
            foreach(var exEnemy in ExtraEnemy)
            {
                if(isFughtBuffConst(exEnemy,GameParams.InstaWinFightBuff))
                {
                    return true;
                } 
            }
            foreach (var player in ReadyPlayers)
            {
               if(player.Value == false){
                   throw new DefautlMesageException("Не все игроки готовы");
                }  
            }
            var buff = enemy.FightBuff(fightPlayer);
            var noItems  = buff == GameParams.NoItemsFightBuff ? true : false;  

            var enemyDmg = EnemyDmg();
            var mainDmg = PlayerDamage(fightPlayer,false);
            var helpDmg=0;
            if(helperPlayer != null && isFughtBuffConst(enemy,GameParams.NohelpFightBuff))
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
            
            var enemies = new List<EnemyCard>();
            enemies.Add(enemy);
            enemies.AddRange(ExtraEnemy);
            var lvls = 0;
            var treasure = 0;
            foreach(var winedEnemy in enemies)
            {
                lvls += winedEnemy.WinLevelsCount;
                treasure = winedEnemy.WinTresureCount;
                var templevels = 0;
                var temptreasure = 0;
                foreach(var buffcard in winedEnemy.baffs)
                {
                    templevels+=buffcard.WinLevelsCount;
                    temptreasure=buffcard.WinTresureCount;
                }
                if(temptreasure >0)
                    treasure += temptreasure;
                if(templevels > 0)
                    lvls += templevels;
            }
            fightPlayer.LevelUp(lvls,true);
            
            for(int i=0;i<treasure;i++)
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
        public bool UseBuff(EnemyBuffCard buff)
        {
            if(enemy == null) throw new DefautlMesageException("Нет мостров");
            if(ExtraEnemy != null) throw new DefautlMesageException("to do EnemyCard UseBuff");//todo if many enemy /// exception
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
            foreach (var buffCard in enemy.baffs)
            {
                enemyDmg+=buffCard.Buff;
            }
            return enemyDmg;
        }
        protected int PlayerDamage(PlayerProfile pp,bool useItems= true)
        {
           return pp.getDmg(useItems);
        }
        private bool isFughtBuffConst(EnemyCard ec,int buffConst)
        {
            if(helperPlayer == null){
                if(ec.FightBuff(fightPlayer)==buffConst)
                    return true;
            }
            else if(ec.FightBuff(fightPlayer)==buffConst || ec.FightBuff(helperPlayer)==buffConst )
                return true;
            return false;
        }       
#endregion
    }
}