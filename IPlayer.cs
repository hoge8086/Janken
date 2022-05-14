namespace JankenGame
{
    interface IPlayer
    {
        string Name { get; }
        Hand GetHand();
    }
}
