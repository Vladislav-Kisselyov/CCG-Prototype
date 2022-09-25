namespace CCG.Hand
{
    using CCG.Card;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerHand : MonoBehaviour, IHand
    {
        public List<ICardBase> Cards { get; private set; } = new ();

        public void DiscardAllCards()
        {
            foreach (ICardBase card in Cards)
                card.OnDiscarded();
            Cards.Clear();
        }

        public void DrawCards(ICardBase[] newCards)
        {
            Cards.AddRange(newCards);
            foreach (ICardBase card in newCards)
                card.SetHand(this);
            RepositionCards();
        }

        public int GetCardCount()
        {
            return Cards.Count;
        }

        public int GetCardIndex(ICardBase card)
        {
            return Cards.IndexOf(card);
        }

        public void OnCardKilled(ICardBase card)
        {
            Cards.Remove(card);
            RepositionCards();
        }

        public void OnCardPlayed(ICardBase card)
        {
            Cards.Remove(card);
            RepositionCards();
        }

        private void RepositionCards()
        {
            foreach (ICardBase card in Cards)
                card.Movement.MoveToHand(true);
        }
    }
}
