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
        public void SetSuperClass(int cardId)
        {
            if(SuperClass == SuperClassEnum.None)
            {
                SuperClassCardId = cardId;
                maxClass = 2;
                SuperClass = SuperClassEnum.Super;
            } else{ 
                throw new DefautlMesageException("У вас уже есть");
            }
        }
        public List<int> LostClass()
        {
            List<int> cardsId = new List<int>();
            if(SuperClass == SuperClassEnum.Super)
            {
                cardsId.Add(SuperClassCardId);
            }
            cardsId.AddRange(ClassCardIdList);
            return cardsId;
        }
        public int DropSupperClass()
        {
           if(SuperClass == SuperClassEnum.Super)
            {
                maxClass = 1;
                SuperClass = SuperClassEnum.None;
                var temp = SuperClassCardId;
                SuperClassCardId = 0;
                return temp;
            } else{ 
                throw new DefautlMesageException("У вас нет суперкласса");
            }
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
        public int DropClass(ClassEnum ce)
        {
            if(ClassList.Contains(ce))
            {
                var cardinListId = ClassList.IndexOf(ce);
                var cardId = ClassCardIdList[cardinListId];
                ClassList.Remove(ce);
                ClassCardIdList.Remove(cardId);
                return cardId;
            } else {
                throw new DefautlMesageException("у вас нет такого класса");
            }
        }
        public bool isClass(ClassEnum ce,bool badEffect = false)
        {
            bool is_class=false;
            foreach(ClassEnum tempCe in ClassList)
            {
                if((tempCe&ce) !=0) is_class = true;            
            }            
            if(badEffect)
            {
               is_class = SuperClass == SuperClassEnum.Super &&  ClassList.Count == 1 ? false : true;
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