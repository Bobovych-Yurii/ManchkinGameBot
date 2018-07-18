using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;

namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public abstract class TresureCard:Card
    {
        public TresureCard(CardParams cp):base(cp){}
    } 
}