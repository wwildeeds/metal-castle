using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace wwild.ui
{
    using wwild.common.itf;
    public class ContentPage : UIBehaviour
    {
        protected static readonly int MIN_ORDER = 0;
        protected static readonly int MAX_ORDER = 3000;

        [Tooltip("canvas component"), SerializeField]
        protected Canvas canvas;

        protected virtual void Init()
        {
        }

        protected virtual void AddListeners()
        { }

        protected virtual void RemoveListeners()
        { }
    }
}
