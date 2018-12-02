using System;
using System.Collections.Generic;
using ManchkinGameApi.Models.Bot;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Cards;
using Telegram.Bot.Types.ReplyMarkups;

namespace ManchkinGameApi.Models.Functions
{
    public static class HandBotFunctions
    {
        private static ClientWrapper cw = BotFactory.Get(BotEnum.HandBot).Result;
        
        public static void SendMessage(long chatId,string message)
        {
            cw.SendTextMessageAsync(chatId,message);
        }
#region Funcs
        public static void SendHand(long chatId,IEnumerable<Card> cards) 
        {
            cw.SendTextMessageAsync(chatId,"====ВАША РУКА====");
            foreach(var card in cards)
            {
                cw.SendPhoto(chatId,card.GameImagePath,"card",GetCardKeyboard(card));
            }
        }
#endregion
        
#region InlineKeyBoards

        public static void SendCards(long chatId,IEnumerable<Card> cards,string header="",string futter="card",ReplyKeyboardMarkup rkm=null)
        {
            var isFirst = true;
            if(header != "")
                HandBotFunctions.SendMessage(chatId,header);
            foreach(var card in cards)
            {
                if(isFirst)
                    cw.SendPhoto(chatId,card.GameImagePath,futter,rkm);
                else
                    cw.SendPhoto(chatId,card.GameImagePath,futter);
                isFirst = false;
                
            }
        }
        public static void SendEquipmentCards(long chatId,IEnumerable<Card> cards,string header)
        {
            
            foreach(var card in cards)
            {
                var button = new InlineKeyboardButton();
                button.Text="Збросить";
                button.CallbackData="/takeof_"+card.Id+"_"+chatId;
                cw.SendTextMessageAsync(chatId,header);
                cw.SendPhoto(chatId,card.GameImagePath,"card",new InlineKeyboardMarkup(button));
            }
        }
       
        public static void SendUsersList(long chatId,long gameId,string header,string command,List<Game.Player.PlayerProfile> ppList)
        {
            List<InlineKeyboardButton> keyboad = new List<InlineKeyboardButton>();
            foreach(var pp in ppList)
            {
                if(chatId == pp.chatId) continue;

                var button = new InlineKeyboardButton();
                button.Text=pp.UserName;
                button.CallbackData="/"+command+"_"+gameId+"_"+pp.UserName;
                keyboad.Add(button);
            }
            cw.SendTextMessageAsync(chatId,header,new InlineKeyboardMarkup(keyboad));
        }

#endregion     

#region Keyboards
       
        public static void SendEqupmentKeyBoard(long chatId)
        {
            

            var temp = 
                new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Commands.CommandsInfo.GetHead.Command), 
                        new KeyboardButton(Commands.CommandsInfo.GetArmor.Command),
                        new KeyboardButton(Commands.CommandsInfo.GetHand.Command),
                        new KeyboardButton(Commands.CommandsInfo.GetFoot.Command),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Ефекты"),
                        new KeyboardButton(Commands.CommandsInfo.PlayerStats.Command), // level class gender Race 
                        new KeyboardButton(Commands.CommandsInfo.GetMainMenu.Command),
                    },

                    
                };
                var rkm = new ReplyKeyboardMarkup(temp,true,false);
                cw.SendTextMessageAsync(chatId,"_", rkm);
        }
        public static void SendKeyboadrd(long chatId,Game.GameState gs=Game.GameState.None,PlayerState ps = PlayerState.Iddle,string message="_")
        {            
                var rkm = GetMainPlayerKeyboard(gs,ps);
                cw.SendTextMessageAsync(chatId,message, rkm);// dont send empty message                
        }
#endregion
       
#region helpers
 private static InlineKeyboardMarkup GetCardKeyboard(Card  card)
        {            
            List<InlineKeyboardButton> keyboad = new List<InlineKeyboardButton>();

            var button = new InlineKeyboardButton();
            button.Text="Play";
            button.CallbackData="/play_"+card.Id;
            keyboad.Add(button);

            button = new InlineKeyboardButton();
            button.Text="Give";
            button.CallbackData="/give_"+card.Id;
            keyboad.Add(button); 
            
            if((card.CardType&CardType.Item)!=0)
            button = new InlineKeyboardButton();
            button.Text="Sell";
            button.CallbackData="/sell_"+card.Id;
            keyboad.Add(button);

            return new InlineKeyboardMarkup(keyboad);
        }
    public static ReplyKeyboardMarkup GetMainPlayerKeyboard(Game.GameState gs=Game.GameState.None,PlayerState ps = PlayerState.Iddle)
    {
        var rkm = new ReplyKeyboardMarkup();

            var tempKeyboard = 
                new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Commands.CommandsInfo.Hand.Command),
                        new KeyboardButton(Commands.CommandsInfo.Equipment.Command), 
                        new KeyboardButton(Commands.CommandsInfo.PlayersLevel.Command), 
                        new KeyboardButton("игроки")
                    },
                    new KeyboardButton[]{}
                };
                
                tempKeyboard[1] = GetPlayerKeyboardHeper(gs,ps);
               
                 
                rkm.Keyboard = tempKeyboard;
                return rkm;
    }
    private static KeyboardButton[] GetPlayerKeyboardHeper(Game.GameState gs,PlayerState ps)
    {
        switch(ps)
        {
            case(PlayerState.OwnTurn):
                return new KeyboardButton[]
                {
                    new KeyboardButton(Commands.CommandsInfo.SellMenu.Command),
                    new KeyboardButton(Commands.CommandsInfo.KickDoor.Command)
                };   
            case(PlayerState.LookTrable):
                return new KeyboardButton[]
                {
                    new KeyboardButton("Чистить нычки"), 
                };
            case(PlayerState.Fight):
                return new KeyboardButton[]
                {
                    new KeyboardButton(Commands.CommandsInfo.CountFight.Command),
                    new KeyboardButton(Commands.CommandsInfo.CallHelp.Command),
                    new KeyboardButton(Commands.CommandsInfo.FinishFight.Command) 
                };
            case(PlayerState.WashOut):
                return new KeyboardButton[]
                {
                    new KeyboardButton("count"),
                    new KeyboardButton(Commands.CommandsInfo.FinishWashOut.Command),
                };
            case(PlayerState.Charity):
                return new KeyboardButton[]
                {
                    new KeyboardButton(Commands.CommandsInfo.SellMenu.Command),//todo
                    new KeyboardButton(Commands.CommandsInfo.EndTurn.Command),
                };
            case(PlayerState.Iddle):
                return GetMinorPlayerKeyboard(gs);
             
            default:
                return new KeyboardButton[]{};
        }
    }
    private static KeyboardButton[] GetMinorPlayerKeyboard(Game.GameState gs)
    {
        switch(gs)
        {
            case(Game.GameState.Fight):
                return new KeyboardButton[]
                {
                    new KeyboardButton(Commands.CommandsInfo.FingtReadyPlayer.Command)
                };
                
            default:
                return new KeyboardButton[]{};
        }
    }
#endregion   
    }
}