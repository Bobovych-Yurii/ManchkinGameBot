using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class DefaultWashOut
    {
        
        int washout;
        private Func<PlayerProfile,bool> isFunc;
        public DefaultWashOut(int washout=0,Func<PlayerProfile,bool> isFunc=null)
        {
            if(isFunc == null)
            isFunc = (PlayerProfile pp)=>{return true;};
            this.isFunc = isFunc;
            this.washout = washout;
        }
        public int WashOut(PlayerProfile pp)
        {
            if(isFunc(pp))
                return washout;
            return 0;
        }
    }
}