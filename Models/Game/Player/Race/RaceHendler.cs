using System;
using System.Collections.Generic;
using ManchkinGameApi.Exeptions;
namespace ManchkinGameApi.Models.Game.Player.Race
{
    public class RaceHendler
    {
        //public SuperClassEnum SuperClass = SuperClassEnum.None;
        public int CocktailCardId;
        public int maxRace = 1;
        public List<RaceEnum> RaceList {get;private set;} = new List<RaceEnum>(){RaceEnum.Humman};
        public List<int> RaceCardIdList {get;private set;} = new List<int>();
        public RaceHendler(){
        }
        public void SetClass(RaceEnum ce,int cardId)
        {
            if(RaceList.Count > maxRace) 
                throw new DefautlMesageException("Збросте класс для взятия нового");
            if(RaceList.Count>1)
            {
                bool is_firest = true;
                foreach(RaceEnum tempCe in RaceList)
                {
                    if(is_firest) {is_firest=false;continue;}
                    if(tempCe == ce) throw new DefautlMesageException("У уже имеете єтот класс");
                }
            }
            RaceList.Add(ce);
            RaceCardIdList.Add(cardId);
        }
        public void DropClass(RaceEnum ce,int cardId)
        {
            if(RaceList.Contains(ce) && RaceCardIdList.Contains(cardId))
            {
                RaceList.Remove(ce);
                RaceCardIdList.Remove(cardId);
                //todo drop card
            } else {
                throw new DefautlMesageException("у вас нет такой рассы");
            }
        }
        public bool isRace(RaceEnum ce,bool badEffect = false)
        {
            bool is_Race=false;
            
            foreach(RaceEnum tempCe in RaceList)
            {
                Console.WriteLine((tempCe&ce).ToString()+"race");
                if((tempCe&ce) !=0) is_Race = true;            
            }            
            if(badEffect)
            {
            //   is_class = SuperClass == SuperClassEnum.Cocktail &&  ClassList.Count == 1 ? false : true;
            }
            return is_Race;
        }
        public IEnumerable<int> GetRaceCardsId(){
            List<int> temp = new List<int>();
            //if(SuperClass!= SuperClassEnum.None)
           //     temp.Add(SuperClassCardId);
            temp.AddRange(RaceCardIdList);
            return temp;
        }
    }
}