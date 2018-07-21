using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class CurceParams:CardParams
    {
        public Action<PlayerProfile> curceFunc;
        public CurceParams(string name,int id,string gameImagePath,CardType ct,GameState gs,
            CardUsage cu,Action<PlayerProfile> pp)
            :base(name,id,gameImagePath,ct,gs,cu)
        {
           curceFunc = curceFunc;
            //todo curces
        }
    }
}