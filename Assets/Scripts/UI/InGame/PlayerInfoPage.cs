using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

namespace wwild.ui.ingame
{
    using Cysharp.Threading.Tasks;

    using wwild.common.itf;
    using wwild.manager;

    public interface IInfoPage
    {
        Action OnInfoChanged { get; }
    }

    public class PlayerInfoPage : BaseContentPage, IContentPage, IInfoPage
    {
        [SerializeField]
        private Button m_buttonCancel;
        [SerializeField]
        private Text m_textInfo;
        public int InstanceID { get; private set; }
        public bool IsActiveInHierarchy { get { return canvas.gameObject.activeInHierarchy; } }

        public Action OnInfoChanged { get; private set; }

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
            InstanceID = this.GetInstanceID();

            OnInfoChanged += () =>
            {
                m_textInfo.text = DataManager.Instance.PlayerStore.PlayerData.StateData.ToString();
            };
        }

        protected override void AddListeners()
        {
            m_buttonCancel.onClick.AddListener(() => OnButtonCancelClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;

            OnInfoChanged?.Invoke();

            canvas.gameObject.SetActive(true);
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
            canvas.gameObject.SetActive(false);
        }

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            Hide();
        }

        public T GetContentInterface<T>() where T : class
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}