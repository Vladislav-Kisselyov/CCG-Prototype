using UnityEngine;

public class CardController : MonoBehaviour
{
    [Header("References to Components")]
    public CardAnimator _Animator;

    private HandController _Hand;
    private CardInfo _Info;

    #region Setters
    public void SetCardInfo(CardInfo newInfo)
    {
        _Info = newInfo;
    }

    private void SetCardHP(int newHP)
    {
        _Info.HP = newHP;
    }

    public void SetCardHP(int newHP, bool shouldAnimate)
    {
        SetCardHP(newHP);
        _Animator.AnimateHP(newHP, shouldAnimate);
    }

    private void SetCardAP(int newAP)
    {
        _Info.AP = newAP;
    }

    public void SetCardAP(int newAP, bool shouldAnimate)
    {
        SetCardAP(newAP);
        _Animator.AnimateAP(newAP, shouldAnimate);
    }

    private void SetCardCost(int newCost)
    {
        _Info.Cost = newCost;
    }

    public void SetCardCost(int newCost, bool shouldAnimate)
    {
        SetCardCost(newCost);
        _Animator.AnimateCost(newCost, shouldAnimate);
    }
    #endregion

    public void InitializeCard(HandController hand, Vector3 position)
    {
        _Hand = hand;
        _Animator.SetInitialState(_Info.Name, _Info.Description, _Info.Sprite, _Info.HP, _Info.AP, _Info.Cost, position);
    }

    public void HPReachedZero()
    {
        _Hand.DestroyCard(this);
    }

    public void DestroyCard()
    {
        Destroy(gameObject);
    }
}
