using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationBase : MonoBehaviour
{
    [Header("Animation Settings")]
    public Ease _Ease = Ease.InOutSine;
    public float _Duration = .4f;

    protected Tween _Tween;
}
