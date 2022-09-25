namespace CCG.Animation.Position
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface ICardBaseMovement
    {
        bool MovementAllowed { get; set; }
        void MoveToHand(bool withAnimation = false);
        void MoveToBoard(Transform board, bool withAnimation = false);
    }
}
