using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class DefaulBuff
    {
        private int buff;
        private Func<PlayerProfile,bool> isFunc;
        public DefaulBuff(int buff,Func<PlayerProfile,bool> isFunc)
        {
            this.buff = buff;
            this.isFunc = isFunc;
        }
        public int GetBuff(PlayerProfile pp)
        {
            if(isFunc(pp))
                return buff;
            return 0;
        }
    }
}