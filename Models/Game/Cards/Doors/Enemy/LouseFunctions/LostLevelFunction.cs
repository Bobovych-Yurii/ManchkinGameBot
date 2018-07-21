using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class LostLevelFunction
    {
        private int lostlevels;

        private Func<PlayerProfile,bool> toLostFunc;
        public LostLevelFunction(int lostLevels,Func<PlayerProfile,bool> toLostFunc= null)
        {
            if(toLostFunc == null)
                toLostFunc=(PlayerProfile pp)=>{return true;};
            this.lostlevels = lostLevels;
            this.toLostFunc = toLostFunc;
        }
        public bool LostLevel(PlayerProfile pp)
        {
            if(toLostFunc(pp))
            pp.LostLevel(lostlevels);
            return true;
        }
    }
}