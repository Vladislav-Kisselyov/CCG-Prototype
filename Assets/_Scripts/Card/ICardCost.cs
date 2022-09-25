namespace CCG.Card
{
    using UnityEngine.Events;

    public interface ICardCost
    {
        int Cost { get; }
        void SetCost(int newCost);
    }
}
