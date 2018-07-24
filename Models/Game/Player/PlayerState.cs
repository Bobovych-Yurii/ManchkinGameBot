using System;
namespace ManchkinGameApi.Models.Game.Player
{
    public enum PlayerState{
        NotReady = 1,
        OwnTurn = 2,
        Fight = 4,
        WashOut = 8,
        Charity = 16,
        Iddle = 32,
        LookTrable = 64,
        RollDise
        //todo set in classes
    }
}