namespace ManchkinGameApi.Models.Game.Player.Items
{
    public enum BodyPartsEnum
    {
        Head = 1,
        Hand = 2,
        Chest = 3,
        Foot = 4,
        Any = Head | Hand | Chest | Foot
    }
}