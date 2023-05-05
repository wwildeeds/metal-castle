using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace wwild.ui.newgame
{
    using wwild.manager;
    using Cysharp.Threading.Tasks;

    public class NewGamePage : BasePage, IDisposable
    {
        [SerializeField]
        private Button m_btnPlay;
        [SerializeField]
        private Button m_btnCancel;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            AddListeners();
        }

        protected override void AddListeners()
        {
            m_btnPlay.onClick.AddListener(() => OnButtonPlayClickAsync().Forget());
            m_btnCancel.onClick.AddListener(() => OnButtonCancelClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_btnPlay.onClick.RemoveAllListeners();
            m_btnCancel.onClick.RemoveAllListeners();
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        #region button events
        private async UniTask OnButtonPlayClickAsync()
        {
            await UniTask.Yield();

        }

        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            SceneManager.Instance.LoadSceneAsync(((int)common.flags.SceneFlags.LoginScene)).Forget();
        }
        #endregion
    }
}