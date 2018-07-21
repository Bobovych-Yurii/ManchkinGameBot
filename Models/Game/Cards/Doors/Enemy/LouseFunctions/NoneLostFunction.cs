using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class NoneLostFunction
    {
        public NoneLostFunction(){}
           
        public bool None(PlayerProfile pp)
        {
            HandBotFunctions.SendMessage(pp.HandBotChatId,"С тобой ничего не случилось");
            return true;
        }
    }
}