namespace CCG.Card
{
    using UnityEngine.Events;

    interface ICardAttack
    {
        int AP { get; }
        void SetAP(int newAP);
    }
}
