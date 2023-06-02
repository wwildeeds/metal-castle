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
        private Button m_buttonDelete;
        [SerializeField]
        private ScrollRect m_scrollRect;

        private List<IHistoryButton> m_historyList;
        [Tooltip("selected history button index")]
        private int m_selectedIndex;

        public int InstanceID { get; private set; }
        public bool IsActiveInHierarchy => canvas.gameObject.activeInHierarchy;

        public bool IsSelected => m_selectedIndex != -1;

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
            m_buttonDelete.onClick.AddListener(() => OnButtonDeleteClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_buttonCancel.onClick.RemoveAllListeners();
            m_buttonPlay.onClick.RemoveAllListeners();
            m_buttonDelete.onClick.RemoveAllListeners();
        }

        private void ResetSelectableMembers()
        {
            m_selectedIndex = -1;
            m_buttonPlay.interactable = false;
            m_buttonDelete.interactable = false;
        }

        private async UniTask InitHistoryDataAsync()
        {
            ResetSelectableMembers();

            await UniTask.WaitUntil(() => DataManager.Instance.Initialized);

            var dataList = DataManager.Instance.PlayerStore.HistoryData.StateList;

            await BuildupHistoryButtonAsync(dataList.Count);

            for (int i = 0; i < dataList.Count; i++)
            {
                var data = dataList[i];
                var idx = m_historyList[i].Index;
                m_historyList[i].SetData(data.Name, data.ID.ToString(), data.CharacterFlag.ToString(), data.Level.ToString());
                m_historyList[i].OnSelected += () => 
                {
                    m_selectedIndex = idx;
                    m_buttonPlay.interactable = true;
                    m_buttonDelete.interactable = true;
                };
            }

        }

        private async UniTask BuildupHistoryButtonAsync(int count)
        {
            await UniTask.WaitUntil(() => SoManager.Instance.Initialized);

            var guiData = SoManager.Instance.GetGuiModel<LoginGuiData>(GuiFlags.LoginGui);
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

            var data = DataManager.Instance.PlayerStore.HistoryData.GetData(m_selectedIndex);

            await DataManager.Instance.PlayerStore.SetPlayerData(data);

            SceneManager.Instance.LoadSceneAsync(((short)data.StateData.SceneFlag), () => 
            {
                var goList = new List<GameObject>();
                if (GameManager.Instance.PlayerPool.HasPlayer)
                {
                }
                else
                {
                    GameManager.Instance.PlayerPool.CreatePlayer();
                }
                if (GameManager.Instance.PlayerPool.HasCamera)
                { }
                else
                {
                    GameManager.Instance.PlayerPool.CreateCamera();
                }

                goList.Add(GameManager.Instance.PlayerPool.MyPlayer);
                goList.Add(GameManager.Instance.PlayerPool.MyCamera);
                return goList.ToArray();
            }).Forget();
        }

        private async UniTask OnButtonDeleteClickAsync()
        {
            await UniTask.Yield();

            var delData = m_historyList[m_selectedIndex];
            m_historyList.Remove(delData);
            delData.Dispose();

            await DataManager.Instance.PlayerStore.RemoveHistoryDataAsync(m_selectedIndex);
            await DataManager.Instance.PlayerStore.OverwriteHistoryDataAsync();

            await InitHistoryDataAsync();
        }
        #endregion
    }
}
