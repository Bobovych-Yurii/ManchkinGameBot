namespace ManchkinGameApi.Models.Game.Cards
{
    public class CardParams
    {
        public string Name {get;}
        public int Id {get;}
        public CardType CardType {get;}
        public GameState GameState {get;}
        public CardUsage CardUsage{get;}
        public string GameImagePath {get;}
        public CardParams(string name,int id,string gameImagePath,CardType ct,GameState gs,CardUsage cu)
        {
            Name = name;
            Id = id;
            GameImagePath = gameImagePath;
            CardType = ct;
            GameState = gs;
            CardUsage = cu;
        }
    }
}