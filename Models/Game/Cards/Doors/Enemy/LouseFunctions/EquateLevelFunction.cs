using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using System.Linq;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class EquateLevelFunction
    {
        
        private Func<PlayerProfile,bool> toLostFunc;
        public EquateLevelFunction(Func<PlayerProfile,bool> toLostFunc=null)
        {
            if(toLostFunc == null)
            toLostFunc = (PlayerProfile pp)=>{return true;};
            this.toLostFunc = toLostFunc;
        }
        public bool LostLevel(PlayerProfile pp)
        {
            if(toLostFunc(pp)){
            List<PlayerProfile> players = pp.game.PlayersList();
            int level = pp.Level-players.Min(p=>p.Level); 
            level = level - pp.Level;
            if(level > 0)
                pp.LevelUp(level);
            else 
                pp.LostLevel(level);
            }
            return true;
        }
    }
}