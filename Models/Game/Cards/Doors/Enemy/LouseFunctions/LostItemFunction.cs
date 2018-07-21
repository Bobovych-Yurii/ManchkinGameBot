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
        private bool isBigSet;
        public LostItemFunction(BodyPartsEnum bp,bool isBig,int count=1)
        {
            this.bp = bp;
            this.count = count;
            this.isBig = isBig;
            this.isBigSet = true;
        }
        public LostItemFunction(BodyPartsEnum bp,int count=1)
        {
            this.bp = bp;
            this.count = count;
        }
        public LostItemFunction(int count=1)
        {
            this.count = count;
        }
        public bool LostItem(PlayerProfile pp)
        {
            if(bp == null)
                pp.LostItem();
            else if(isBigSet)
                pp.LostItem(bp,isBig,count);
            else pp.LostItem(bp,count);
            return true;
        }
    }
}