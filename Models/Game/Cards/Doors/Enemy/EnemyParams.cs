using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class EnemyParams:CardParams
    {
        public int Level;
        public int WinLevelsCount;
        public int WinTresureCount;
        public Func<PlayerProfile,bool> LostFunction;
        public Func<PlayerProfile,int> FightBuff; 
        public Func<PlayerProfile,int> WasOut;

        public EnemyParams(string name,int id,string gameImagePath,CardType ct,GameState gs,
            CardUsage cu,int level,int winLevelsCount,int winTresureCount,
            Func<PlayerProfile,bool> lostFunction,Func<PlayerProfile,int> fightBuff,Func<PlayerProfile,int> wasOut)
            :base(name,id,gameImagePath,ct,gs,cu)
        {
            this.Level = level;
            this.WinLevelsCount = winLevelsCount;
            this.WinTresureCount = winTresureCount;
            this.LostFunction = lostFunction;
            this.FightBuff = fightBuff;
            this.WasOut = wasOut;
        }
    }
}