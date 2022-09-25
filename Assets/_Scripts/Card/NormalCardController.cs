namespace CCG.Card
{
    using CCG.Animation.Position;
    using CCG.Hand;
    using UnityEngine;
    using UnityEngine.Events;

    public class NormalCardController : MonoBehaviour, ICardBase, ICardHealth, ICardCost, ICardAttack
    {
        [Header("Events on some Stat Changed")]
        [SerializeField] private UnityEvent _onNameChanged;
        [SerializeField] private UnityEvent _onDescriptionChanged;
        [SerializeField] private UnityEvent _onSpriteChanged;
        [SerializeField] private UnityEvent _onAPChanged;
        [SerializeField] private UnityEvent _onHPChanged;
        [SerializeField] private UnityEvent _onCostChanged;

        void Awake()
        {
            Movement = GetComponent<CardArkMovement>();
        }

        #region Interface Autofields
        public int HP { get; private set; } = 1;
        public int Cost { get; private set; } = 1;
        public int AP { get; private set; } = 1;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Sprite Sprite { get; private set; }
        public ICardBaseMovement Movement { get; set; }
        public IHand Hand { get; set; }
        #endregion
        #region Interface Methods
        public void SetAP(int newAP)
        {
            int oldValue = AP;
            AP = newAP;
            if (AP != oldValue)
                _onAPChanged?.Invoke();
        }

        public void SetCost(int newCost)
        {
            int oldValue = Cost;
            Cost = newCost;
            if (Cost != oldValue)
                _onCostChanged?.Invoke();
        }

        public void SetDescription(string newDescription)
        {
            string oldValue = Description;
            Description = newDescription;
            if (Description != oldValue)
                _onDescriptionChanged?.Invoke();
        }

        public void SetHP(int newHP)
        {
            int oldValue = HP;
            HP = newHP;
            if (HP != oldValue)
                _onHPChanged?.Invoke();
        }

        public void SetName(string newName)
        {
            string oldValue = Name;
            Name = newName;
            if (Name != oldValue)
                _onNameChanged?.Invoke();
        }

        public void SetSprite(Sprite newSprite)
        {
            Sprite oldSprite = Sprite;
            Sprite = newSprite;
            if (Sprite != oldSprite)
                _onSpriteChanged?.Invoke();
        }

        public void OnDiscarded()
        {
            Destroy(gameObject);
        }

        public void OnPlayed(Transform board)
        {
            Hand.OnCardPlayed(this);
            Movement.MoveToBoard(board);
        }

        public void OnKilled()
        {
            Hand.OnCardKilled(this);
            Destroy(gameObject);
        }
        #endregion
    }
}
