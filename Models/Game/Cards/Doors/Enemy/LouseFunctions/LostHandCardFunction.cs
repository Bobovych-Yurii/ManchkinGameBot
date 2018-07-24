using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class LostHandCardFunction
    {
        private int count;
        public LostHandCardFunction(int count)
        {
            this.count = count;
        }
        public bool LostHand(PlayerProfile pp)
        {
            pp.LostCard(count);
            return true;
        }
    }
}