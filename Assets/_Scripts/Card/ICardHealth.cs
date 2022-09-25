namespace CCG.Card
{
    using UnityEngine.Events;

    public interface ICardHealth
    {
        int HP { get; }
        void SetHP(int newHP);
        void OnKilled();
    }
}