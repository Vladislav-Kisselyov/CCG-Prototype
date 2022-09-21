using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkPositionCalculator : MonoBehaviour
{
    public float _ArkRadius = 200f;
    public float _ArkSectionRadMax = 0.5f;
    public float _ArkSectionRadMin = 0.3f;
    public float _ArkOffsetY = 100f;

    private Vector3 _Anchor;

    public Vector3 CalculatePositionOfCardAtIndex(int cardIndex, int cardsNum)
    {
        _Anchor = new Vector3((Screen.width / 2f), -_ArkRadius +_ArkOffsetY, 0);
        float arkLengthCoeff = Mathf.Lerp(_ArkSectionRadMax, _ArkSectionRadMin, 1f / cardsNum);
        float totalArkLength = Mathf.PI * arkLengthCoeff;
        float singleSectionLength = totalArkLength / cardsNum;
        float finalAngle = cardIndex * singleSectionLength;
        finalAngle += singleSectionLength * 0.5f; //this positions angle @mid of the section
        finalAngle += Mathf.PI * 0.5f; //Unity's 0 rad is actually at 0.5f*rad
        finalAngle -= totalArkLength * 0.5f; //this offsets angle to set midpoint @ 12 o'clock
        Vector3 newPos = _Anchor + new Vector3(Mathf.Cos(finalAngle), Mathf.Sin(finalAngle), 0) * _ArkRadius;
        return newPos;
    }
}
