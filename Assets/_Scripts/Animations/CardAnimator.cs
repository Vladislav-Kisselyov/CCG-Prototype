using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardAnimator : MonoBehaviour
{
    [Header("References to Dynamic Animation Components")]
    public AnimationTextCounter _AnimationHP;
    public AnimationTextCounter _AnimationAP;
    public AnimationTextCounter _AnimationCost;
    public AnimationSmoothPosition _AnimationPosition;

    [Header("References to Static Text Components")]
    public TextMeshProUGUI _TextName;
    public TextMeshProUGUI _TextDescription;

    [Header("Reference to Filler Image Component")]
    public Image _ImageFiller;

    public void AnimateHP(int endValue, bool finishInstantly)
    {
        _AnimationHP.Animate(endValue, finishInstantly);
    }
    public void AnimateAP(int endValue, bool finishInstantly)
    {
        _AnimationAP.Animate(endValue, finishInstantly);
    }
    public void AnimateCost(int endValue, bool finishInstantly)
    {
        _AnimationCost.Animate(endValue, finishInstantly);
    }
    public void AnimatePosition(Vector3 newPosiition, bool finishInstantly)
    {
        _AnimationPosition.Animate(newPosiition, finishInstantly);
    }
    public void SetName(string newName)
    {
        _TextName.SetText(newName);
    }
    public void SetDescription(string newDescription)
    {
        _TextDescription.SetText(newDescription);
    }
    public void SetSprite(Sprite newSprite) {
        _ImageFiller.sprite = newSprite;
    }

    public void SetInitialState(string name, string description, Sprite sprite, int hp, int ap, int cost, Vector3 position)
    {
        SetName(name);
        SetDescription(description);
        SetSprite(sprite);
        AnimateHP(hp, true);
        AnimateAP(ap, true);
        AnimateCost(cost, true);
        AnimatePosition(position, true);
    }
}
