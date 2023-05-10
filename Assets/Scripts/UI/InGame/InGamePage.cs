using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace wwild.ui.ingame
{
    using Cysharp.Threading.Tasks;

    using wwild.manager;
    using wwild.common.flags;
    using wwild.common.itf;
    using wwild.scriptableObjects;
    public class InGamePage : BasePage, IBucket<IContentPage>, IDisposable
    {
        [SerializeField]
        private Button m_buttonPlayerInfo;
        [SerializeField]
        private Button m_buttonPlayerSkill;
        [SerializeField]
        private Button m_buttonPlayerInventory;
        [SerializeField]
        private Button m_buttonSetting;

        private Dictionary<int, IContentPage> m_bucket;
        public bool IsBucketEmpty => m_bucket.Count == 0;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            Init();

            AddListeners();
        }

        public override void Init()
        {
            base.Init();

            m_bucket = new Dictionary<int, IContentPage>();
        }

        protected override void AddListeners()
        {
            m_buttonPlayerInfo.onClick.AddListener(() => OnButtonPlayerInfoClickAsync().Forget());
            m_buttonPlayerSkill.onClick.AddListener(() => OnButtonPlayerSkillClickAsync().Forget());
            m_buttonPlayerInventory.onClick.AddListener(() => OnButtonPlayerInventoryClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_buttonPlayerInfo.onClick.RemoveAllListeners();
            m_buttonPlayerSkill.onClick.RemoveAllListeners();
            m_buttonPlayerInventory.onClick.RemoveAllListeners();
        }

        public void PushObj(IContentPage obj)
        {
            if (m_bucket.ContainsKey(obj.InstanceID))
            {
                var page = m_bucket[obj.InstanceID];
                if (page.IsActiveInHierarchy) page.Hide();
                else page.Show();
            }
            else
            {
                m_bucket.Add(obj.InstanceID, obj);
                obj.Show();
            }
        }

        [Obsolete("not support in InGamePage", true)]
        public IContentPage PeekObj()
        {
            return null;
        }

        [Obsolete("not support in InGamePage", true)]
        public IContentPage PopObj()
        {
            return null;
        }

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonPlayerInfoClickAsync()
        {
            await UniTask.Yield();
            var key = ((short)PlayerGuiFlags.PlayerInfo);

            if (IsRegisteredObj(key) == false)
            {
                var path = SoManager.Instance.GetGuiData<PlayerGuiData>(GuiFlags.PlayerGui).PlayerInfoPage;
                var obj = await Resources.LoadAsync(path) as GameObject;
                var go = Instantiate(obj, Vector3.zero, Quaternion.identity);
                RegisterObj(key, go.GetComponent<IContentPage>());
            }

            var page = GetRegisteredObj(key);
            PushObj(page);
        }

        private async UniTask OnButtonPlayerSkillClickAsync()
        {
            await UniTask.Yield();
            var key = ((short)PlayerGuiFlags.PlayerSkill);

            if (IsRegisteredObj(key) == false)
            {
                var path = SoManager.Instance.GetGuiData<PlayerGuiData>(GuiFlags.PlayerGui).PlayerSkillPage;
                var obj = await Resources.LoadAsync(path) as GameObject;
                var go = Instantiate(obj, Vector3.zero, Quaternion.identity);
                RegisterObj(key, go.GetComponent<IContentPage>());
            }

            var page = GetRegisteredObj(key);
            PushObj(page);
        }

        private async UniTask OnButtonPlayerInventoryClickAsync()
        {
            await UniTask.Yield();

            var key = ((short)PlayerGuiFlags.PlayerInventory);
            if (IsRegisteredObj(key) == false)
            {
                var path = SoManager.Instance.GetGuiData<PlayerGuiData>(GuiFlags.PlayerGui).PlayerInventoryPage;
                var obj = await Resources.LoadAsync(path) as GameObject;
                var go = Instantiate(obj, Vector3.zero, Quaternion.identity);
                RegisterObj(key, go.GetComponent<IContentPage>());
            }

            var page = GetRegisteredObj(key);
            PushObj(page);
        }
        #endregion
    }
}