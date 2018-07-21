using System;
using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Exeptions;
using ManchkinGameApi.Models.Functions;
namespace ManchkinGameApi.Models.Game.Cards
{
    public abstract class Card
    {
        public int Id {get;}
        public string Name {get;}
        public CardType CardType {get;}
        public GameState GameState {get;}
        public CardUsage CardUsage{get;}
        public string GameImagePath {get;}

        public Card(CardParams cp)
        {
            Id = cp.Id;
            Name = cp.Name;
            GameImagePath = cp.GameImagePath;
            CardType = cp.CardType;
            GameState = cp.GameState;
            CardUsage = cp.CardUsage;
        }   
        public void Play(Game game,string PlayerUserName)
        {
            Console.WriteLine(game.GameState + "   "+ game.GameState);
            if((game.GameState&game.GameState) == 0) throw new  DefautlMesageException("нельзя сыграть карту сейчас");
            if(game.GameState == GameState && game.GetCurrnetPlayer().UserName != PlayerUserName) 
                throw new DefautlMesageException("карту можно использоваь только в свой ход");
                
            InPlay(game,PlayerUserName);
            if((this.CardType & CardType.Enemy|CardType.Buff)==0)
                game.Discard(this,PlayerUserName); //todo discardEnemy
            else
                game.Discard(this,PlayerUserName,true);
            GameBotFunctions.ShowUserCard(game.ChatId,this,"@"+PlayerUserName+" сыграл");
            
        }
        protected bool isPlayerTurn(Player.PlayerProfile currentpp ,string player){
            if( currentpp.UserName != player) throw new DefautlMesageException("можно сыграть только в свой ход перед и после боя");
            return true;
        }
        protected abstract void InPlay(Game game, string PlayerUserName);
    }
}