using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Commands;

namespace ManchkinGameApi.Models.Bot 
{
    public  class BotSettings
    {
        public virtual  string Url {get;set;}
        public virtual  string Name {get;set;}
        public virtual  string Key {get;set;}
        public virtual  List<Command> Commands {get;set;}
    }
    public  class  ManckinHandBotSettings:BotSettings
    {
        public override string Url {get;set;} ="https://be784927.ngrok.io/api/Bot/ManchkinHand/";
        public override string Name {get;set;}="manckinHandBot";
        public override string Key {get;set;}="583959567:AAEtSg-vpaRMhrBFLvlzdDrSF_kSTU583U0";
        public override List<Command> Commands {get;set;}= new List<Command>() {new HelloCommand()};
    }
    public  class ManckinGameBotSettings:BotSettings
    {
        public override string Url {get;set;}="https://be784927.ngrok.io/api/Bot/ManchkinGame/" ;
        public override string Name {get;set;}="manckinGameBot";        
        public override string Key {get;set;}="603234017:AAH9XCzApPkfQVuM9RoTe28MnTzJHQ-acMo";
        public override List<Command> Commands {get;set;} = new List<Command>() 
        {new HelloCommand(), new NewGame(),
        new EndGame(),new TakeIngamePlace(),
        new StartGame()};
        
    }
}
