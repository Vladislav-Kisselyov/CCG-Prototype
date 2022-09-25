namespace CCG.Animation.Text
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface ITextAnimetable
    {
        void Animate(int endValue, bool finishInstantly = false);
    }
}
