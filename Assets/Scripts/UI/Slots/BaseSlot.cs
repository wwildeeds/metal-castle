using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace wwild.ui.slot
{
    public abstract class BaseSlot : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected Button slotButton;
        protected bool interactable;

        protected abstract void Init();

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}
