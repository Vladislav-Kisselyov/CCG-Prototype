using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{
    private string _Name;
    private string _Description;
    private Sprite _Sprite;
    private CardStats _Stats;

    public CardInfo(string name, string description, Sprite sprite, int hp, int ap, int cost)
    {
        _Name = name;
        _Description = description;
        _Sprite = sprite;
        _Stats = new CardStats(ap, hp, cost);
    }

    public string Name { get => _Name; set => _Name = value; }
    public string Description { get => _Description; set => _Description = value; }
    public Sprite Sprite { get => _Sprite; set => _Sprite = value; }
    public CardStats Stats { get => _Stats; set => _Stats = value; }
    public int AP { get => _Stats.AP; set => _Stats.AP = value; }
    public int HP { get => _Stats.HP; set => _Stats.HP = value; }
    public int Cost { get => _Stats.Cost; set => _Stats.Cost = value; }
}
