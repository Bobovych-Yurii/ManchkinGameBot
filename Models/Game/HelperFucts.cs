using System;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Functions;
using System.Collections.Generic;
namespace ManchkinGameApi.Models.Helpers
{
    public class IsClassHelper
    {
        private ClassEnum pClass;
        public IsClassHelper(ClassEnum pClass)
        {
            this.pClass = pClass;
        }
        public bool IsClass(PlayerProfile pp)
        {
            return pp.isClass(pClass);
        }
    }
    public class IsRaceHelper
    {
        private RaceEnum pRace;
        public IsRaceHelper(RaceEnum pRace)
        {
            this.pRace = pRace;
        }
        public bool IsRace(PlayerProfile pp)
        {
            return pp.isRace(pRace);
        }
    }
    public class IsListHelper
    {
        private List<Func<PlayerProfile,bool>> funcs;
        public IsListHelper(List<Func<PlayerProfile,bool>> funcs)
        {
            this.funcs = funcs;
        }
        public bool IsList(PlayerProfile pp)
        {
            bool isAllTrue = false;
            foreach(var func in funcs)
            {
                if(!func(pp)) isAllTrue = false;
            }
            return isAllTrue;
        }
    }  
}