using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [Header("Component References")]
    public CardSpawner _CardSpawner;
    public ArkPositionCalculator _CardPositioner;
    public DropBoardController _DropBoardController;

    [Header("Private Properties Peek")]
    [SerializeField] private List<CardController> _ActiveCards = new List<CardController>();

    public void Start()
    {
        TryFillHandWithRandomCards();
    }

    public void TryFillHandWithRandomCards()
    {
        _CardSpawner.TryToGenerateCards();
    }

    public void OnCardGenerationComplete()
    {
        DestroyAllCards();
        _ActiveCards.AddRange(_CardSpawner.GeneratedCards);
        InitializeActiveCards();
    }

    public void InitializeActiveCards()
    {
        for (int i = 0; i < _ActiveCards.Count; i++)
            _ActiveCards[i].InitializeCard(this, _CardPositioner.CalculatePositionOfCardAtIndex(i, _ActiveCards.Count));
    }

    public void RepositionAllCards()
    {
        for (int i = 0; i < _ActiveCards.Count; i++)
            _ActiveCards[i]._Animator.AnimatePosition(_CardPositioner.CalculatePositionOfCardAtIndex(i, _ActiveCards.Count), false);
    }

    public void DestroyAllCards()
    {
        _DropBoardController.DestroyAllCards();
        foreach (CardController card in _ActiveCards)
            card.DestroyCard();
        _ActiveCards.Clear();
    }

    public void DestroyCard(CardController card)
    {
        _ActiveCards.Remove(card);
        RepositionAllCards();
        card.DestroyCard();
    }

    public void PlayCard(CardController card)
    {
        card.transform.SetParent(_DropBoardController.transform);
        card._Animator._AnimationPosition.FreezePosition();
        ActiveCards.Remove(card);
        RepositionAllCards();
    }

    public List<CardController> ActiveCards { get => _ActiveCards; set => _ActiveCards = value; }
}
