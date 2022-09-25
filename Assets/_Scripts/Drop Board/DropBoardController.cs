namespace CCG.DropBoard
{
    using CCG.Card;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DropBoardController : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            ICardBase card = eventData.pointerDrag.GetComponent<ICardBase>();
            if (card != null)
                card.OnPlayed(transform);
        }

        public void DestroyAllCards()
        {
            foreach (NormalCardController card in GetComponentsInChildren<NormalCardController>())
                Destroy(card.gameObject);
        }
    }
}
