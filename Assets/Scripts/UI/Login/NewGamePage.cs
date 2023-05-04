using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace wwild.ui.login
{
    using Cysharp.Threading.Tasks;

    using wwild.common.itf;
    public class NewGamePage : BaseContentPage, IContentPage
    {
        public int InstanceID { get; private set; }

        private IContainer<short, IContentPage> m_icontainer;
        private IBucket<IContentPage> m_ibucket;

        [Tooltip("cancel button"), SerializeField]
        private Button m_btnCancel;

        protected override void Awake()
        {
            InstanceID = this.GetInstanceID();

            Init();
        }

        protected override void Start()
        {
            //AddListeners();
        }

        protected override void Init()
        {
            var rootPage = FindObjectOfType<LoginPage>();

            if (rootPage == null) throw new NullReferenceException();

            m_icontainer = rootPage;
            m_ibucket = rootPage;
        }

        protected override void AddListeners()
        {
            m_btnCancel.onClick.AddListener(() => OnButtonCancelClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_btnCancel.onClick.RemoveAllListeners();
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
        }

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
        }
        #endregion
    }
}