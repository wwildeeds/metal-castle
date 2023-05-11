using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wwild.ui.login
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.flags;
    using wwild.manager;
    using wwild.scriptableObjects;
    public class HistoryPage : BaseContentPage, IContentPage
    {
        private IBucket<IContentPage> m_parentBucket;

        [SerializeField]
        private Button m_buttonCancel;
        [SerializeField]
        private Button m_buttonPlay;

        public int InstanceID { get; private set; }

        public bool IsActiveInHierarchy => canvas.gameObject.activeInHierarchy;

        protected override void Awake()
        {
            Init();
        }

        protected override void Start()
        {
            AddListeners();
        }

        protected override void Init()
        {
            m_parentBucket = FindObjectOfType<LoginPage>();
        }

        protected override void AddListeners()
        {
            m_buttonCancel.onClick.AddListener(() => OnButtonCancelClickAsync().Forget());
            m_buttonPlay.onClick.AddListener(() => OnButtonPlayClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_buttonCancel.onClick.RemoveAllListeners();
            m_buttonPlay.onClick.RemoveAllListeners();
        }

        private async UniTask InitHistoryDataAsync()
        {
            await UniTask.Yield();

            await UniTask.WaitUntil(() => DataManager.Instance.Initialized);

            var dataList = DataManager.Instance.GetPlayerHistory().StateList;

            for (int i = 0; i < dataList.Count; i++)
            {

            }
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

        #region button events
        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            m_parentBucket.PopObj().Hide();
        }

        private async UniTask OnButtonPlayClickAsync()
        {
            await UniTask.Yield();

            //show loading popup

            await InitHistoryDataAsync();

            //hide loading popup
        }
        #endregion
    }
}
