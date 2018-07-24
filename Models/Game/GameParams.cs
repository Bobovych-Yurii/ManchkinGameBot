namespace ManchkinGameApi.Models.Game
{
    public static class GameParams
    {
        public static int MaxCardsInHand = 5;
        public static int MaxLevel = 10;
        public static int MaxPlayers = 6;
        public static int StartCardsCount = 8;
        public static int NoneWashOut = 1000;

        public static int NoItemsFightBuff = -1000;
        public static int NohelpFightBuff = -1001;
        public static int InstaWinFightBuff = -1002;
    }
}