using ManchkinGameApi.Models.Game.Player;
using System.Collections.Generic;
namespace ManchkinGameApi
{
    public static class MyExtentions
    {
        public static bool Contains(this List<PlayerProfile> pplist,PlayerProfile pp)
        {
         //todo Check if work    
            foreach(var tempPp in pplist)
            {
                if(pp.UserName == tempPp.UserName) return true;    
            }
            return false;
        }
    }
}