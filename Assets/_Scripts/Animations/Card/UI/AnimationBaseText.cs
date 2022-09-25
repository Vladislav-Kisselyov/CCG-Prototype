namespace CCG.Animation.Text
{
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class AnimationBaseText : AnimationBase
    {
        protected TextMeshProUGUI _TextComp;
        private void Awake()
        {
            _TextComp = GetComponent<TextMeshProUGUI>();
        }
    }
}
