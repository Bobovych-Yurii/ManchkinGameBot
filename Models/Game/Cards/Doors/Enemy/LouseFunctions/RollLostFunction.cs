using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class RollLostFunction
    {
        Func<PlayerProfile,int,bool> rollLostFunc;
        public RollLostFunction(Func<PlayerProfile,int,bool> rollLostFunc){
           this.rollLostFunc = rollLostFunc;
        }
        public bool Roll(PlayerProfile pp)
        {
            var roll = Dise.Roll();
            HandBotFunctions.SendMessage(pp.chatId,"Вы рольнули "+roll);
            pp.game.RollHendler = new RollHendler(pp,roll,AfterRoll);
            return false;
        }
        public void AfterRoll(PlayerProfile pp,int roll)
        {
            var isEndLostFunct = rollLostFunc(pp,roll);
            pp.game.FinishWashOut(pp,isEndLostFunct);
        }
    }
}