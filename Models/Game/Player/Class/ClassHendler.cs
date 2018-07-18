using System;
using System.Collections.Generic;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Game;
namespace ManchkinGameApi.Models.Game.Player.Class
{
    public class ClassHendler
    {
        public SuperClassEnum SuperClass = SuperClassEnum.None;
        public int SuperClassCardId;
        public int maxClass = 1;
        public List<ClassEnum> ClassList {get;private set;} = new List<ClassEnum>(){ClassEnum.None}; 
        public List<int> ClassCardIdList {get;private set;} = new List<int>();
        public ClassHendler(){
        }
        public void SetClass(ClassEnum ce,int cardId)
        {
            if(ClassList.Count > maxClass) 
                throw new DefautlMesageException("Збросте класс для взятия нового");
            if(ClassList.Count>1)
            {
                bool is_firest = true;
                foreach(ClassEnum tempCe in ClassList)
                {
                    if(is_firest) {is_firest=false;continue;}
                    if(tempCe == ce) throw new DefautlMesageException("У уже имеете єтот класс");
                }
            }
            ClassList.Add(ce);
            ClassCardIdList.Add(cardId);
        }
        public void DropClass(ClassEnum ce,int cardId)
        {
            if(ClassList.Contains(ce) && ClassCardIdList.Contains(cardId))
            {
                ClassList.Remove(ce);
                ClassCardIdList.Remove(cardId);
            } else {
                throw new DefautlMesageException("у вас нет такого класса");
            }
        }
        public bool isClass(ClassEnum ce,bool badEffect = false)
        {
            bool is_class=false;
            foreach(ClassEnum tempCe in ClassList)
            {
                Console.WriteLine((tempCe&ce).ToString() +"class");
                if((tempCe&ce) !=0) is_class = true;            
            }            
            if(badEffect)
            {
               is_class = SuperClass == SuperClassEnum.Cocktail &&  ClassList.Count == 1 ? false : true;
            }
            return is_class;
        }
        public IEnumerable<int> GetClassCardsId(){
            List<int> temp = new List<int>();
            if(SuperClass!= SuperClassEnum.None)
                temp.Add(SuperClassCardId);
            temp.AddRange(ClassCardIdList);
            return temp;
        }
    }
}