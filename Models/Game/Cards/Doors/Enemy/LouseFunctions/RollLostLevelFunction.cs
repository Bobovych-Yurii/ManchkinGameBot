using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class RollLostLevelFunction
    {
        private Func<PlayerProfile,bool> toLostFunc;
        public RollLostLevelFunction(Func<PlayerProfile,bool> toLostFunc= null)
        {
            if(toLostFunc == null)
                toLostFunc=(PlayerProfile pp)=>{return true;};
            
            this.toLostFunc = toLostFunc;
        }
        public bool LostLevel(PlayerProfile pp,int levels)
        {
            if(toLostFunc(pp))
            pp.LostLevel(levels);
            return true;
        }
    }
}