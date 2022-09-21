using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardSpawner : MonoBehaviour
{
    [Header("Component Reference")]
    public WebSpriteLoader _SpriteLoader;
    public Transform _ParentTransform;

    [Header("Prefab Reference")]
    public CardController _CardPrefab;

    [Header("Hand Filling Settings")]
    [Range(1, 10)]
    public int _MinCardsNum = 4;
    [Range(1, 10)]
    public int _MaxCardsNum = 6;
    [Range(1, 10)]
    public int _MinCardStat = 5;
    [Range(1, 10)]
    public int _MaxCardStat = 10;

    [Header("On Cards Generation Complete")]
    public UnityEvent _OnCardsGenerationComplete;

    private int _RandomNum = 0;
    private List<CardController> _GeneratedCards = new List<CardController>();

    public void TryToGenerateCards()
    {
        ClearGeneratedCards();
        _RandomNum = Random.Range(_MinCardsNum, _MaxCardsNum + 1);
        _SpriteLoader.TryToRequestSprites(_RandomNum);
    }

    public void OnSpriteRequestComplete()
    {
        if (_SpriteLoader.DownloadedSprites.Count == _RandomNum)
            GenerateCards();
        else
            Debug.LogWarning(string.Format("Not enough sprites downloaded from web. Expected: {0}; Result: {1}", _RandomNum, _SpriteLoader.DownloadedSprites.Count));
    }

    private void GenerateCards()
    {
        for (int i = 0; i < _RandomNum; i++)
        {
            CardInfo newCardInfo = new ("Card " + i, "Description " + i, _SpriteLoader.DownloadedSprites[i],
                Random.Range(_MinCardStat, _MaxCardStat), Random.Range(_MinCardStat, _MaxCardStat), Random.Range(_MinCardStat, _MaxCardStat));
            CardController newCard = Instantiate(_CardPrefab, Vector3.zero, Quaternion.identity, _ParentTransform);
            newCard.SetCardInfo(newCardInfo);
            _GeneratedCards.Add(newCard);
        }
        _SpriteLoader.ClearDownloadedSprites();
        _OnCardsGenerationComplete.Invoke();
    }

    public void ClearGeneratedCards()
    {
        _GeneratedCards.Clear();
    }

    public List<CardController> GeneratedCards { get => _GeneratedCards; set => _GeneratedCards = value; }
}
