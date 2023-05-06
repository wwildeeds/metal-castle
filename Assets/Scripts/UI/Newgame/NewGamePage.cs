using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace wwild.ui.newgame
{
    using wwild.manager;
    using wwild.controller.newgame;
    using Cysharp.Threading.Tasks;

    public class NewGamePage : BasePage, IDisposable
    {
        [SerializeField]
        private Button m_btnPlay;
        [SerializeField]
        private Button m_btnCancel;

        [Tooltip("description game obj"), SerializeField]
        private GameObject m_description;
        [Tooltip("selected class info text"), SerializeField]
        private Text m_textHeader;
        [Tooltip("selected class description text"), SerializeField]
        private Text m_textDescription;

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
            var tempCtrl = GameObject.FindObjectOfType<SelectionController>();
            tempCtrl.OnSelectedUnit += (info, desc) =>
            {
                if (string.IsNullOrEmpty(info) && string.IsNullOrEmpty(desc))
                {
                    m_description.SetActive(false);
                    return;
                }
                m_textHeader.text = info;
                m_textDescription.text = desc;
                m_description.SetActive(true);
            };
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