namespace CCG.Card
{
    using CCG.Animation.Position;
    using CCG.Hand;
    using UnityEngine;

    public interface ICardBase
    {
        string Name { get; }
        string Description { get; }
        Sprite Sprite { get; }
        ICardBaseMovement Movement { get; }
        IHand Hand { get; set; }

        void SetName(string newName);
        void SetDescription(string newDescription);
        void SetSprite(Sprite newSprite);
        void SetHand(IHand hand)
        {
            Hand = hand;
        }
        void OnDiscarded();
        void OnPlayed(Transform board);
    }
}
