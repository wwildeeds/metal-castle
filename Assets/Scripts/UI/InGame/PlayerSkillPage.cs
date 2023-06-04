using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wwild.ui.ingame
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;

    public interface ISkillPage
    { }
    public class PlayerSkillPage : BaseContentPage, IContentPage
    {
        [SerializeField]
        private Button m_buttonCancel;

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

            InstanceID = this.GetInstanceID();
        }

        protected override void AddListeners()
        {
            m_buttonCancel.onClick.AddListener(() => OnButtonCancelClickAsync().Forget());
        }

        protected override void RemoveListeners()
        {
            m_buttonCancel.onClick.RemoveAllListeners();
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;
            canvas.gameObject.SetActive(true);
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
            canvas.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        #region button events
        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            Hide();
        }

        public T GetContentInterface<T>() where T : class
        {
            var finded = this.TryGetComponent<T>(out var cmp);

            return finded ? cmp : null;
        }
        #endregion
    }
}