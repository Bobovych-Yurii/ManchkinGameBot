using System;
namespace ManchkinGameApi.Models.Game
{
    public enum GameState{
        Preparation = 0b0000_0001,
        StartGame= 0b0000_0010,
        KickDoor = 0b0000_0100,
        LookRoom = 0b0000_1000,
        LookTrable = 0b0001_0000,
        Charity = 0b0010_0000

    }
}