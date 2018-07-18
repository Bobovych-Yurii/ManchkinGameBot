using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;

namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public abstract class DoorCard:Card
    {
        public DoorCard(CardParams cp):base(cp){}
    } 
}