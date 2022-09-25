namespace CCG.Testers.StatsChanger
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using DG.Tweening;
    using CCG.Hand;
    using CCG.Card;

    public class RandomStatsChangeController : MonoBehaviour
    {
        [Header("Component References")]
        public PlayerHand _Hand;

        [Header("Random Settings")]
        public int _MinValue = -2;
        public int _MaxValue = 9;
        public float _PauseBeforeNextCard = 0.2f;

        private Sequence _Sequence;
        public void StartRandomChange()
        {
            if (_Hand.Cards.Count > 0)
            {
                _Sequence?.Kill();
                _Sequence = DOTween.Sequence();
                foreach (NormalCardController card in _Hand.Cards)
                {
                    _Sequence.AppendInterval(_PauseBeforeNextCard).AppendCallback(() =>
                    {
                        card.SetHP(Random.Range(_MinValue, _MaxValue + 1));
                        card.SetAP(Random.Range(_MinValue, _MaxValue + 1));
                        card.SetCost(Random.Range(_MinValue, _MaxValue + 1));
                    });
                }
                _Sequence.OnComplete(() => { _Sequence = null; });
                _Sequence.SetInverted().Play();
            }
        }
    }
}
