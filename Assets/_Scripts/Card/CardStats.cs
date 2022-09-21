using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats
{
    private int _AP;
    private int _HP;
    private int _Cost;

    public CardStats(int aP, int hP, int cost)
    {
        _AP = aP;
        _HP = hP;
        _Cost = cost;
    }

    public int AP { get => _AP; set => _AP = value; }
    public int HP { get => _HP; set => _HP = value; }
    public int Cost { get => _Cost; set => _Cost = value; }
}
