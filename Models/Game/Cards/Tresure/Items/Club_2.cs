using ManchkinGameApi.Models.Game;
using ManchkinGameApi.Models.Game.Cards;
using ManchkinGameApi.Models.Game.Player;
using ManchkinGameApi.Models.Game.Player.Class;
using ManchkinGameApi.Models.Game.Player.Items;
using ManchkinGameApi.Exeptions;
using System;
namespace ManchkinGameApi.Models.Game.Cards.Tresure
{
    public class Club_2:ItemCard
    {
        public Club_2()
            :base("club_2"){}
        protected override void InPlay(Game game,string playerUserName)
        {            
            var pp = game.GetCurrnetPlayer();
            if(isPlayerTurn(pp,playerUserName))
            {
                if(pp.GetGender() == PlayerGender.Mele || (pp.GetPlayerStatistic().IsGenderChanged && pp.GetGender() == PlayerGender.Femele))
                {
                    Console.WriteLine("on equip");       
                    pp.EquipItem(this);
                } else {
                    throw new DefautlMesageException("Ваш пол не подходит");
                }
            }
            
        }
    }
}