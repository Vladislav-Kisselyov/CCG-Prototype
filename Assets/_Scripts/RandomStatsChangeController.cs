using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomStatsChangeController : MonoBehaviour
{
    [Header("Component References")]
    public HandController _Hand;

    [Header("Random Settings")]
    public int _MinValue = -2;
    public int _MaxValue = 9;
    public float _PauseBeforeNextCard = 0.2f;

    private Sequence _Sequence;
    public void StartRandomChange()
    {
        if (_Hand.ActiveCards.Count > 0)
        {
            _Sequence?.Kill();
            _Sequence = DOTween.Sequence();
            List<CardController> reversedCards = new List<CardController>();
            reversedCards.AddRange(_Hand.ActiveCards);
            reversedCards.Reverse();
            foreach (CardController card in reversedCards)
            {
                _Sequence.AppendCallback(() => { 
                    card.SetCardHP(Random.Range(_MinValue, _MaxValue + 1), false);
                    card.SetCardAP(Random.Range(_MinValue, _MaxValue + 1), false);
                    card.SetCardCost(Random.Range(_MinValue, _MaxValue + 1), false);
                }).AppendInterval(_PauseBeforeNextCard);
            }
            _Sequence.OnComplete(() => { _Sequence = null; });
            _Sequence.Play();
        }
    }
}
