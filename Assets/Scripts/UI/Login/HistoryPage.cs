using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wwild.ui.login
{
    using wwild.common.itf;
    public class HistoryPage : BaseContentPage, IContentPage
    {
        [SerializeField]
        private Button m_buttonCancel;
        [SerializeField]
        private Button m_buttonPlay;

        public int InstanceID { get; private set; }

        public bool IsActiveInHierarchy => canvas.gameObject.activeInHierarchy;

        protected override void Init()
        {
        }

        protected override void AddListeners()
        {
        }

        protected override void RemoveListeners()
        {
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;
        }

        public void Dispose()
        {
        }
    }
}
