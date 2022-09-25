namespace CCG.Hand
{
    using CCG.Card;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IHand
    {
        List<ICardBase> Cards { get; }
        void OnCardKilled(ICardBase card);
        void OnCardPlayed(ICardBase card);
        void DrawCards(ICardBase[] newCards);
        void DiscardAllCards();
        int GetCardIndex(ICardBase card);
        int GetCardCount();
    }
}
