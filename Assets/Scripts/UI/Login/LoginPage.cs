using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace wwild.ui.login
{
    using Cysharp.Threading.Tasks;

    using wwild.ui;
    using wwild.common.itf;
    using wwild.manager;

    public enum LoginFlags : short
    { 
        Newgame,
        Option
    }

    public class LoginPage : BasePage, IBucket<IContentPage>, IDisposable
    {
        private Stack<IContentPage> m_bucket;

        [Tooltip("new game button component"), SerializeField]
        private Button m_btnNewgame;
        [Tooltip("option button component"), SerializeField]
        private Button m_btnOption;
        [Tooltip("exist button component"), SerializeField]
        private Button m_btnExist;

        public bool IsBucketEmpty => m_bucket.Count == 0;

        protected override void Awake()
        {
            Init();
        }

        protected override void Start()
        {
            AddListeners();
        }

        public override void Init()
        {
            base.Init();

            m_bucket = new Stack<IContentPage>();
        }

        protected override void AddListeners()
        {
            m_btnNewgame.onClick.AddListener(() => OnButtonNewGameClickAsync().Forget());
            m_btnOption.onClick.AddListener(() => OnButtonOptionClickAsync().Forget());
            m_btnExist.onClick.AddListener(() => OnButtonExistClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_btnNewgame.onClick.RemoveAllListeners();
            m_btnOption.onClick.RemoveAllListeners();
            m_btnExist.onClick.RemoveAllListeners();
        }

        public void PushObj(IContentPage obj)
        {
            if (obj == null) throw new NullReferenceException();

            if (IsBucketEmpty == false)
            {
                if (PeekObj().InstanceID == obj.InstanceID) return;

                var temp = PopObj();
                temp.Hide();
            }

            m_bucket.Push(obj);
            obj.Show();
        }

        public IContentPage PeekObj()
        {
            if (IsBucketEmpty) return null;

            return m_bucket.Peek();
        }

        public IContentPage PopObj()
        {
            if (IsBucketEmpty) return null;

            return m_bucket.Pop();
        }

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonNewGameClickAsync()
        {
            if (IsRegisteredObj(((short)LoginFlags.Newgame)) == false)
            {
                var obj = await Resources.LoadAsync(LoginSceneManager.Instance.ScenePrefabs.NewgamePage) as GameObject;

                var go = GameObject.Instantiate<GameObject>(obj, Vector3.zero, Quaternion.identity);

                RegisterObj(((short)LoginFlags.Newgame), go.GetComponent<NewGamePage>());
            }

            await UniTask.Yield();

            var page = GetRegisteredObj(((short)LoginFlags.Newgame));

            PushObj(page);
        }

        private async UniTask OnButtonOptionClickAsync()
        {
            await UniTask.Yield(PlayerLoopTiming.LastUpdate);
        }

        private async UniTask OnButtonExistClickAsync()
        {
            await UniTask.Yield(PlayerLoopTiming.LastUpdate);
        }
        #endregion

    }
}