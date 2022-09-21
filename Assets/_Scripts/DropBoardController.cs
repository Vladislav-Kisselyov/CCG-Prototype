using UnityEngine;
using UnityEngine.EventSystems;

public class DropBoardController : MonoBehaviour, IDropHandler
{
    public HandController _Hand;
    public void OnDrop(PointerEventData eventData)
    {
        CardController card = eventData.pointerDrag.GetComponent<CardController>();
        if (card != null)
            _Hand.PlayCard(card);
    }

    public void DestroyAllCards()
    {
        foreach (CardController card in GetComponentsInChildren<CardController>())
            card.DestroyCard();
    }
}
