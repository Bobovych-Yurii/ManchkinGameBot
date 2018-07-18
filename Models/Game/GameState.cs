using System;
namespace ManchkinGameApi.Models.Game
{
    public enum GameState{
        None=0,
        Preparation=1,
        StartTurn=4,
        KickDoor=8,
        Fight=16,
        LookRoom=32,
        LookTrable=64,
        Charity=128,
        WashOut=256,
        All = Preparation | StartTurn | KickDoor
            | Fight| LookRoom| LookTrable| Charity| WashOut,
        Play = StartTurn | KickDoor
            | Fight| LookRoom | LookTrable| Charity| WashOut

    }
}