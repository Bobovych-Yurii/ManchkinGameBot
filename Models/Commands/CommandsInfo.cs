using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Game;
namespace ManchkinGameApi.Models.Commands
{
    public static partial class CommandsInfo{
        public static readonly CommandInfo FingtReadyPlayer = new CommandInfo(){Command="Конец боя",StateAllow=GameState.All ,Name="FingtReadyPlayer"};
        public static readonly CommandInfo Hello = new CommandInfo(){Command="/hello",StateAllow=GameState.All ,Name="hello"};
        public static readonly CommandInfo EndGame = new CommandInfo(){Command="/endgame",StateAllow=GameState.All,Name="EndGame"};
        public static readonly CommandInfo NewGame = new CommandInfo(){Command="/newgame",StateAllow=GameState.All,Name="NewGame"};
        public static readonly CommandInfo StarGame = new CommandInfo(){Command="/startgame",StateAllow=GameState.Preparation,Name="StarGame"};
        public static readonly CommandInfo TakeInGamePlace = new CommandInfo(){Command="/takeingameplace",StateAllow=GameState.Preparation,Name="TakeInGamePlace"};
        public static readonly CommandInfo StartHandBot = new CommandInfo(){Command="/start",StateAllow=GameState.All,Name="Start"};
        public static readonly CommandInfo PlayCard = new CommandInfo(){Command="/play",StateAllow=GameState.OwnTurn,Name="Play"};
        public static readonly CommandInfo GiveCard = new CommandInfo(){Command="/give",StateAllow=GameState.OwnTurn,Name="Give"};
        public static readonly CommandInfo SellCard = new CommandInfo(){Command="/sell",StateAllow=GameState.OwnTurn,Name="Sell"};
        public static readonly CommandInfo Hand = new CommandInfo(){Command="Рука",StateAllow=GameState.Play,Name="Hand"};
        public static readonly CommandInfo Equipment = new CommandInfo(){Command="Снаряжение",StateAllow=GameState.Play,Name="Hand"};
        public static readonly CommandInfo Class = new CommandInfo(){Command="Класс",StateAllow=GameState.Play,Name="Class"};
        public static readonly CommandInfo GetMainMenu = new CommandInfo(){Command="Назад",StateAllow=GameState.Play,Name="GetMainMenu"};
        public static readonly CommandInfo PlayerStats = new CommandInfo(){Command="Статы",StateAllow=GameState.Play,Name="Stats"};
        public static readonly CommandInfo PlayersLevel = new CommandInfo(){Command="Уровни",StateAllow=GameState.Play,Name="UsersLevel"};

        public static readonly CommandInfo GetArmor = new CommandInfo(){Command="Броник",StateAllow=GameState.Play,Name="GetArmot"};
        public static readonly CommandInfo GetHand = new CommandInfo(){Command="Руки",StateAllow=GameState.Play,Name="GetHand"};
        public static readonly CommandInfo GetHead = new CommandInfo(){Command="Голова",StateAllow=GameState.Play,Name="GetHead"};
        public static readonly CommandInfo GetFoot = new CommandInfo(){Command="Ноги",StateAllow=GameState.Play,Name="GetFoot"};
        public static readonly CommandInfo Players = new CommandInfo(){Command="Игроки",StateAllow=GameState.Play,Name="Players"}; //todo
        public static readonly CommandInfo KickDoor = new CommandInfo(){Command="Вышибаем двери",StateAllow=GameState.StartTurn,Name="KickDoor"};
        public static readonly CommandInfo FinishFight = new CommandInfo(){Command="Закончить бой",StateAllow=GameState.Fight,Name="FinishFight"};
        public static readonly CommandInfo CountFight = new CommandInfo(){Command="Посчитать",StateAllow=GameState.Fight,Name="CountFight"};
        public static readonly CommandInfo CallHelp = new CommandInfo(){Command="Хелп",StateAllow=GameState.Fight,Name="CallHelp"};
        public static readonly CommandInfo FinishWashOut = new CommandInfo(){Command="Смываться",StateAllow=GameState.WashOut,Name="FinishWashOut"};
        public static readonly CommandInfo EndTurn = new CommandInfo(){Command="Хакончить ход",StateAllow=GameState.Charity,Name="EndTurn"};
        public static readonly CommandInfo SellAll = new CommandInfo(){Command="/allsell",StateAllow=GameState.OwnTurn,Name="SellAll"};
        public static readonly CommandInfo UndoSell = new CommandInfo(){Command="/undosell",StateAllow=GameState.OwnTurn,Name="UndoSell"};
        public static readonly CommandInfo SellMenu = new CommandInfo(){Command="Продать",StateAllow=GameState.OwnTurn,Name="SellMenu"};
        public static readonly CommandInfo Chouse = new CommandInfo(){Command="/chouse",StateAllow=GameState.All,Name="Chouse"};
        
    }

    public class CommandInfo
    {
        public string Command;
        public string Name;
        public GameState StateAllow;
        
    }
}