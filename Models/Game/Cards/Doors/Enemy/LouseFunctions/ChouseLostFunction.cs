using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Models.Game.Player.Race;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Cards.Doors
{
    public class ChouseLostFunction
    {
        private Dictionary<string,Func<PlayerProfile,bool>> chouseFuncs;
        public ChouseLostFunction(Dictionary<string,Func<PlayerProfile,bool>> messageFuncs){
            chouseFuncs = messageFuncs;
        }
           
        public bool Chouse(PlayerProfile pp)
        {
            pp.game.Chouse.SetChouse(pp,PlayerChouse);
            var temp = "Выберите :\n";
            var i=0;
            foreach(var item in chouseFuncs)
            {
                i++;
                temp+=item.Key+"\n"+Commands.CommandsInfo.Chouse.Command+"_"+i+"\n";
                
            }
            HandBotFunctions.SendMessage(pp.HandBotChatId,temp);
            return false;
        }
        public void PlayerChouse(PlayerProfile pp,int index)
        {
            var enumerator = chouseFuncs.GetEnumerator();
            for(int i=0;i<index;i++)
            {
                enumerator.MoveNext();
            }
            enumerator.Current.Value(pp);
            pp.game.FinishWashOut(pp,true);
        }
    }
}