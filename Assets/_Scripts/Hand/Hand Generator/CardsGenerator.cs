namespace CCG.Hand.Generator
{
    using CCG.Card;
    using CCG.Hand;
    using CCG.Hand.SpriteLoader;
    using System.Collections.Generic;
    using UnityEngine;

    public class CardsGenerator : MonoBehaviour
    {
        [Header("Object Reference")]
        [SerializeField] private PlayerHand _hand;
        [SerializeField] private WebSpriteLoader _spriteLoader;
        [SerializeField] private Transform _parentTransform;

        [Header("Prefab Reference")]
        [SerializeField] private NormalCardController _cardPrefab;
        [SerializeField] private Sprite _defaultSprite;

        [Header("Hand Filling Settings")]
        [Range(1, 10)]
        [SerializeField] private int _minCardsNum = 4;
        [Range(1, 10)]
        [SerializeField] private int _maxCardsNum = 6;
        [Range(1, 10)]
        [SerializeField] private int _minCardStat = 5;
        [Range(1, 10)]
        [SerializeField] private int _maxCardStat = 10;

        private int _randomNum = 0;
        private List<NormalCardController> GeneratedCards { get; set; } = new();
        public void Start()
        {
            TryToGenerateCards();
        }
        public void TryToGenerateCards()
        {
            ClearGeneratedCards();
            _randomNum = Random.Range(_minCardsNum, _maxCardsNum + 1);
            _spriteLoader.TryToRequestSprites(_randomNum);
        }

        public void OnSpriteLoadCompletion()
        {
            if (_spriteLoader.DownloadedSprites.Count == _randomNum)
                Debug.Log("Downloaded " + _randomNum + " sprites succesfully!");
            else
            {
                Debug.LogWarning(string.Format("Not enough sprites downloaded from URL. Expected: {0}; Result: {1}. Generating with default sprite!", _randomNum, _spriteLoader.DownloadedSprites.Count));
                Debug.LogWarning("Check URL availability or internet connection");
            }
            GenerateCards();
        }

        private void GenerateCards()
        {
            for (int i = 0; i < _randomNum; i++)
            {
                NormalCardController newCard = Instantiate(_cardPrefab, Vector3.zero, Quaternion.identity, _parentTransform);
                newCard.SetAP(Random.Range(_minCardStat, _maxCardStat));
                newCard.SetHP(Random.Range(_minCardStat, _maxCardStat));
                newCard.SetCost(Random.Range(_minCardStat, _maxCardStat));
                newCard.SetName("Name " + i);
                newCard.SetDescription("Description " + i);
                if (_spriteLoader.DownloadedSprites.Count == _randomNum)
                    newCard.SetSprite(_spriteLoader.DownloadedSprites[i]);
                else
                    newCard.SetSprite(_defaultSprite);
                GeneratedCards.Add(newCard);
            }
            _hand.DrawCards(GeneratedCards.ToArray());
            ClearGeneratedCards();
        }

        public void ClearGeneratedCards()
        {
            GeneratedCards.Clear();
        }
    }
}