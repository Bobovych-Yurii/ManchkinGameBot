using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class EnemyBuffParams:CardParams
    {
        public int Buff;
        public int WinLevelsCount;
        public int WinTresureCount;
        
        public EnemyBuffParams(string name,int id,string gameImagePath,CardType ct,GameState gs,
            CardUsage cu,int buff,int winLevelsCount,int winTresureCount)
            :base(name,id,gameImagePath,ct,gs,cu)
        {
            this.Buff = buff;
            this.WinLevelsCount = winLevelsCount;
            this.WinTresureCount = winTresureCount;
            
        }
    }
}