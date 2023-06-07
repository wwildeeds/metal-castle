using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wwild.ui.ingame
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.data;
    using wwild.ui.slot;

    public interface ISkillPage
    {
        void RegisterSkills(CharacterSkillData[] skillsData);
    }
    public class PlayerSkillPage : BaseContentPage, IContentPage, ISkillPage
    {
        [SerializeField]
        private Button m_buttonCancel;
        [SerializeField]
        private List<SkillSlot> m_skillList;

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

        public void RegisterSkills(CharacterSkillData[] skillsData)
        {
            for (int i = 0; i < m_skillList.Count; i++)
            {
                m_skillList[i].RegisterSkill(skillsData[i]);
            }
        }

        public void Dispose()
        {
            m_skillList.ForEach(s => s.Dispose());
            m_skillList.Clear();
            m_skillList = null;
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