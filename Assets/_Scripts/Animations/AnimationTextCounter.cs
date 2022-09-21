using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AnimationTextCounter : AnimationBase
{
    public UnityEvent _UponReachingZero;
    private TextMeshProUGUI _TextComp;
    private int _Value;
    private void FindReference()
    {
        _TextComp = GetComponent<TextMeshProUGUI>();
    }

    public void Animate(int endValue, bool finishInstantly)
    {
        if (_TextComp == null)
            FindReference();

        _Tween?.Kill();
        if (!finishInstantly)
        {
            _Tween = DOTween.To(() => _Value, x => _Value = x, endValue, _Duration).SetEase(_Ease)
                .OnUpdate(()=> {
                    _TextComp.SetText(_Value.ToString());
                    if (_Value < 0)
                        OnZeroReached();
                })
                .OnComplete(() => {
                    if (_Value <= 0)
                        OnZeroReached();
                });
        }
        else
        {
            _Value = endValue;
            _TextComp.SetText(_Value.ToString());
            if (_Value <= 0)
                OnZeroReached();
        }
    }

    private void OnZeroReached()
    {
        if (_UponReachingZero != null)
        {
            _Tween?.Kill();
            _UponReachingZero.Invoke();
        }
    }
}
