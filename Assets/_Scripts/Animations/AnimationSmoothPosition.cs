using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationSmoothPosition : AnimationBase, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _TargetPosition;
    private Vector3 _DragOffset;
    public CanvasGroup _CanvasGroup;
    public GameObject _Particles;
    private bool isFrozen = false;

    public void Animate(Vector3 endValue, bool finishInstantly)
    {
        if (!isFrozen)
        {
            _TargetPosition = endValue;
            _Tween?.Kill();
            if (!finishInstantly)
            {
                _Tween = transform.DOMove(_TargetPosition, _Duration).SetEase(_Ease);
            }
            else
            {
                transform.position = endValue;
            }
        }
    }
    
    public void FreezePosition()
    {
        _Tween?.Kill();
        isFrozen = true;
        _CanvasGroup.blocksRaycasts = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _DragOffset = transform.position - Input.mousePosition;
        _Particles.SetActive(true);
        _CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + _DragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _Particles.SetActive(false);
        Animate(_TargetPosition, false);
        _CanvasGroup.blocksRaycasts = !isFrozen;
    }
}
