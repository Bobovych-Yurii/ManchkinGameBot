using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class LostItemFunction
    {
        private BodyPartsEnum bp;
        private int count;
        private bool isBig;
        public LostItemFunction(BodyPartsEnum bp,int count=1,bool isBig=false)
        {
            this.bp = bp;
            this.count = count;
            this.isBig = isBig;
        }
        public void LostItem(PlayerProfile pp)
        {
            pp.LostItem(bp,isBig,count);
        }
    }
}