namespace CCG.Animators
{
    using CCG.Animation.Text;
    using CCG.Card;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CardAnimator : MonoBehaviour
    {
        [Header("Card Reference")]
        [SerializeField] private NormalCardController _card;

        [Header("References to Dynamic Animation Components")]
        [SerializeField] private AnimationTextCounter _animationHP;
        [SerializeField] private AnimationTextCounter _animationAP;
        [SerializeField] private AnimationTextCounter _animationCost;

        [Header("References to Static Text Components")]
        [SerializeField] private TextMeshProUGUI _TextName;
        [SerializeField] private TextMeshProUGUI _TextDescription;

        [Header("Reference to Filler Image Component")]
        [SerializeField] private Image _ImageFiller;

        public void Start()
        {
            SetInitialState();
        }

        public void AnimateHP(bool finishInstantly)
        {
            _animationHP.Animate(_card.HP, finishInstantly);
        }
        public void AnimateAP(bool finishInstantly)
        {
            _animationAP.Animate(_card.AP, finishInstantly);
        }
        public void AnimateCost(bool finishInstantly)
        {
            _animationCost.Animate(_card.Cost, finishInstantly);
        }
        public void SetName()
        {
            _TextName.SetText(_card.Name);
        }
        public void SetDescription()
        {
            _TextDescription.SetText(_card.Description);
        }
        public void SetSprite()
        {
            _ImageFiller.sprite = _card.Sprite;
        }
        public void SetInitialState()
        {
            SetName();
            SetDescription();
            SetSprite();
            AnimateHP(true);
            AnimateAP(true);
            AnimateCost(true);
        }
    }
}
