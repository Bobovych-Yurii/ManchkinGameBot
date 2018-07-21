using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Commands;
using ManchkinGameApi.Models.Game.Player.Items;
namespace ManchkinGameApi.Models.Bot 
{
    public  class BotSettings
    {
        public virtual  string Url {get;set;}
        public virtual  string Name {get;set;}
        public virtual  string Key {get;set;}
        public virtual  List<Command> Commands {get;set;}
        public virtual BotEnum BotType{get;set;}
    }
    public  class  ManckinHandBotSettings:BotSettings
    {
        public override string Url {get;set;} ="https://2225ac7a.ngrok.io/api/Bot/ManchkinHand/";
        public override string Name {get;set;}="manchkinHandBot";
        public override string Key {get;set;}="583959567:AAEtSg-vpaRMhrBFLvlzdDrSF_kSTU583U0";
        public override List<Command> Commands {get;set;}= new List<Command>() 
        {
            new HelloCommand(),new StartHandBot(), new GiveCard(), new PlayCard(), new SellCard(),
            new EquipmentMenu(),new HandComand(),new SendStats(), new SendMainMenu(),new SendUsersLevel(),
            new SendBodyEquipment(CommandsInfo.GetArmor,BodyPartsEnum.Chest),
            new SendBodyEquipment(CommandsInfo.GetFoot,BodyPartsEnum.Foot),
            new SendBodyEquipment(CommandsInfo.GetHead,BodyPartsEnum.Head),
            new SendBodyEquipment(CommandsInfo.GetHand,BodyPartsEnum.Hand),
            new KickDoor(), new FinishFight(),new CountFight(), new FinishWashOut(),
            new CallHelp(), new FinishCharity(), new SellAll(), new UndoSell(),
            new SellMenu(),new Chouse()
        };
        public override BotEnum BotType {get;set;} = BotEnum.HandBot;
    }
    public  class ManckinGameBotSettings:BotSettings
    {
        public override string Url {get;set;}="https://2225ac7a.ngrok.io/api/Bot/ManchkinGame/";
        public override string Name {get;set;}="manchkinBot";
        public override string Key {get;set;}="603234017:AAH9XCzApPkfQVuM9RoTe28MnTzJHQ-acMo";
        public override BotEnum BotType {get;set;} = BotEnum.GameBot;
        public override List<Command> Commands {get;set;} = new List<Command>() 
        {
            new HelloCommand(), new NewGame(),
            new EndGame(),new TakeIngamePlace(),
            new StartGame()}
        ;
        
    }
}
