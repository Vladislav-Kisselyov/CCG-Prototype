namespace CCG.Animation.Position
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class CardDragMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CanvasGroup _CanvasGroup;
        [SerializeField] private GameObject _Particles;
        [SerializeField] private CardArkMovement _ArkMovement;

        private Vector3 _DragOffset;
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
            _CanvasGroup.blocksRaycasts = _ArkMovement.MovementAllowed;
            _ArkMovement.MoveToHand(true);
        }
    }
}
