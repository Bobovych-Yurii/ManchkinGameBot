using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class LvlWashOut
    {
        int minLevel;
        int washout;
        public LvlWashOut(int minLevel =-1,int washout=0)
        {
            this.minLevel = minLevel;
            this.washout = washout;
        }
        public int WashOut(PlayerProfile pp)
        {
            if(pp.Level <= minLevel) return GameParams.NoneWashOut;
            return washout;
        }
    }
}