namespace CCG.Animation.Text{
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.Events;

    public class AnimationTextCounter : AnimationBaseText, ITextAnimetable
    {
        [Header("Callback On Timer Reaching 0")]
        [SerializeField] private UnityEvent _UponZeroReached;
        private int _Value;

        public void Animate(int endValue, bool finishInstantly = false)
        {
            _Tween?.Kill();
            if (!finishInstantly)
            {
                _Tween = DOTween.To(() => _Value, x => _Value = x, endValue, _Duration).SetEase(_Ease)
                    .OnUpdate(() => {
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
            if (_UponZeroReached != null)
            {
                _Tween?.Kill();
                _UponZeroReached.Invoke();
            }
        }
    }
}