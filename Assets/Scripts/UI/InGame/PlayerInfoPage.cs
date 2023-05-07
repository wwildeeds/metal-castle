using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wwild.ui.ingame
{
    using Cysharp.Threading.Tasks;
    using System;
    using wwild.common.itf;

    public class PlayerInfoPage : BaseContentPage, IContentPage
    {
        [SerializeField]
        private Button m_buttonCancel;

        public int InstanceID { get; private set; }
        public bool IsActiveInHierarchy { get { return canvas.gameObject.activeInHierarchy; } }

        protected override void Start()
        {
            Init();

            AddListeners();
        }

        protected override void Init()
        {
            InstanceID = this.GetInstanceID();
        }

        protected override void AddListeners()
        {
            m_buttonCancel.onClick.AddListener(() => OnButtonCancelClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;
            canvas.gameObject.SetActive(true);
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
            canvas.gameObject.SetActive(false);
        }

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            Hide();
        }
        #endregion
    }
}
