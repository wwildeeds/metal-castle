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

            //Init();
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
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
        }

        public void PushObj(IContentPage obj)
        {
            if (IsBucketEmpty == false)
            {
                if (m_bucket.ContainsKey(obj.InstanceID))
                {
                    var page = m_bucket[obj.InstanceID];
                    if (page.IsActiveInHierarchy) page.Hide();
                    else page.Show();
                    return;
                }
            }

            m_bucket.Add(obj.InstanceID, obj);
            obj.Show();
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

            if (IsRegisteredObj(((short)InGameUIFlags.PlayerInfo)) == false)
            {
                var obj = await Resources.LoadAsync(GameManager.Instance.InGameScenePref.PlayerInfoPage) as GameObject;
                var go = Instantiate(obj, Vector3.zero, Quaternion.identity);
                RegisterObj(((short)InGameUIFlags.PlayerInfo), go.GetComponent<IContentPage>());
            }

            var page = GetRegisteredObj(((short)InGameUIFlags.PlayerInfo));
            PushObj(page);
        }
        #endregion
    }
}
