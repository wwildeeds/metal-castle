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
    public class LoginPage : BasePage, IDisposable
    {

        [Tooltip("new game button component"), SerializeField]
        private Button m_btnNewgame;
        [Tooltip("option button component"), SerializeField]
        private Button m_btnOption;
        [Tooltip("exist button component"), SerializeField]
        private Button m_btnExist;

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
            m_containers = new Dictionary<string, IContentPage>();
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

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonNewGameClickAsync()
        {
            await UniTask.Yield(PlayerLoopTiming.LastUpdate);

            IsRegisteredObj("");
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