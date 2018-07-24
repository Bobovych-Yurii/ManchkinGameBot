using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Cards.Doors;
using ManchkinGameApi.Exeptions;
using System.Linq;
namespace ManchkinGameApi.Models.Game
{
    public class RollHendler
    {
        private Player.PlayerProfile pp;
        private int roll;
        private Action<PlayerProfile,int> afterRollFunc;
        public RollHendler(Player.PlayerProfile pp,int roll,Action<PlayerProfile,int> afterRollFunc)
        {
            this.pp = pp;
            this.roll = roll;
            this.afterRollFunc = afterRollFunc;
        }
        public void Finish(PlayerProfile pp,int reRoll =-1)
        {
            if(this.pp != pp) throw new DefautlMesageException("Не вам делать рерол");
            if(reRoll !=-1) roll = reRoll;
            afterRollFunc(pp,roll);
        }
    }
}