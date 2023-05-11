using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
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
        [SerializeField]
        private ScrollRect m_scrollRect;

        private List<IHistoryButton> m_historyList;

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
            m_historyList = new List<IHistoryButton>();
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

            await BuildupHistoryButtonAsync(dataList.Count);

            for (int i = 0; i < dataList.Count; i++)
            {
                var data = dataList[i];
                m_historyList[i].SetData(data.Name, data.ID.ToString(), data.CharacterFlag.ToString(), data.Level.ToString());
            }

        }

        private async UniTask BuildupHistoryButtonAsync(int count)
        {
            await UniTask.WaitUntil(() => SoManager.Instance.Initialized);

            var guiData = SoManager.Instance.GetGuiData<LoginGuiData>(GuiFlags.LoginGui);
            var tempBtn = guiData.HistoryButton;

            var curCount = m_scrollRect.content.childCount;
            var remain = Mathf.Abs(curCount - count);
            if (curCount > count)
            {
                for (int i = 0; i < remain; i++)
                {
                    var data = m_historyList[m_historyList.Count - 1];
                    m_historyList.RemoveAt(m_historyList.Count - 1);
                    data.Dispose();
                }

            }
            else if (curCount < count)
            {
                for (int i = 0; i < remain; i++)
                {
                    var go = Instantiate<GameObject>(tempBtn);
                    go.transform.SetParent(m_scrollRect.content);
                    m_historyList.Add(go.GetComponent<IHistoryButton>());
                }
            }
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;

            InitHistoryDataAsync().Forget();
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
