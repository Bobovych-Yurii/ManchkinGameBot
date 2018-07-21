using System;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game
{
    public class Chouse
    {
        private PlayerProfile pp; 
        private Action<PlayerProfile,int> chouseFunc;
        public void SetChouse(PlayerProfile pp,Action<PlayerProfile,int> chouseFunc)
        {
            this.pp = pp;
            this.chouseFunc = chouseFunc;
        }
        public void MakeChouse(PlayerProfile pp,int index)
        {
            if(this.chouseFunc == null) throw new DefautlMesageException("нечего выбирать");
            if(this.pp != pp) throw new DefautlMesageException("не вам выбирать");
            
            chouseFunc(pp,index);
            chouseFunc = null;
        }
        public bool isChouseFunc()
        {
            return chouseFunc == null;
        }
    }
}