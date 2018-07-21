using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class RaceClassBuff
    {
        private int buff;
        private ClassEnum playerClass;
        private RaceEnum playerRace;
        public RaceClassBuff(int buff,ClassEnum playerClass,RaceEnum playerRace)
        {
            this.buff = buff;
            this.playerClass = playerClass;
            this.playerRace = playerRace;
        }
        public int GetBuff(PlayerProfile pp)
        {
            if(pp.isClass(playerClass) && pp.isRace(playerRace))
            {
                return buff;
            }
            return 0;
        }
    }
}