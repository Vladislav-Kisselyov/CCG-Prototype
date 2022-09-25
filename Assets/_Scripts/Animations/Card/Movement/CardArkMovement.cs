namespace CCG.Animation.Position
{
    using CCG.Card;
    using CCG.Hand;
    using DG.Tweening;
    using UnityEngine;

    public class CardArkMovement : AnimationBase, ICardBaseMovement
    {
        [Header("Ark Movement Settings")]
        [SerializeField] private Transform _target;
        [SerializeField] private float _arkRadius = 200f;
        [SerializeField] private float _arkSectionRadMax = 0.5f;
        [SerializeField] private float _arkSectionRadMin = 0.2f;
        [SerializeField] private float _arkOffsetY = 120f;
        private Vector3 _handAnchor;
        private ICardBase _card;
        private IHand _hand;

        public bool MovementAllowed { get; set; } = true;

        private void Awake()
        {
            _card = GetComponent<ICardBase>();
            _hand = _target.parent.parent.GetComponent<IHand>();
        }

        public void MoveToHand(bool withAnimation = true)
        {
            if (MovementAllowed)
            {
                Vector3 newPos = CalculateTargetPositionInHand();
                _Tween?.Kill();
                if (withAnimation)
                {
                    _Tween = _target.DOMove(newPos, _Duration).SetEase(_Ease);
                }
                else
                {
                    _target.position = newPos;
                }
            }
        }

        public void MoveToBoard(Transform board, bool withAnimation = true)
        {
            MovementAllowed = false;
            _target.SetParent(board);
        }

        public Vector3 CalculateTargetPositionInHand()
        {
            //int childIndex = _target.GetSiblingIndex();
            //int childNum = _target.parent.childCount;
            int childIndex = _hand.GetCardIndex(_card);
            int childNum = _hand.GetCardCount();

            _handAnchor = new Vector3((Screen.width / 2f), -_arkRadius + _arkOffsetY, 0);
            float arkLengthCoeff = Mathf.Lerp(_arkSectionRadMax, _arkSectionRadMin, 1f / childNum);
            float totalArkLength = Mathf.PI * arkLengthCoeff;
            float singleSectionLength = totalArkLength / childNum;
            float finalAngle = childIndex * singleSectionLength;
            finalAngle += singleSectionLength * 0.5f; //this positions angle @mid of the section
            finalAngle += Mathf.PI * 0.5f; //Unity's 0 rad is actually at 0.5f*rad
            finalAngle -= totalArkLength * 0.5f; //this offsets angle to set midpoint @ 12 o'clock
            Vector3 newPos = _handAnchor + new Vector3(Mathf.Cos(finalAngle), Mathf.Sin(finalAngle), 0) * _arkRadius;
            return newPos;
        }
    }
}
