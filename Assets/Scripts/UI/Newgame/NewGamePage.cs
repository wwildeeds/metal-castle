using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;


namespace wwild.ui.newgame
{
    using wwild.manager;
    using wwild.controller.newgame;
    using wwild.scriptableObjects;
    using wwild.common.flags;
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

        private StringBuilder m_str;

        public Action<bool, CharacterFlags> OnSelectedUnitAsync { get; private set; }
        private CharacterFlags m_selectedCharFlag;

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
            m_str = new StringBuilder();
            
            OnSelectedUnitAsync += async (isSelected, flag) => 
            {
                await UniTask.WaitUntil(() => SoManager.Instance.Initialized);

                if (isSelected == false)
                {
                    m_selectedCharFlag = CharacterFlags.None;
                    m_description.SetActive(false);
                    return;
                }

                m_str.Clear();
                m_selectedCharFlag = flag;

                var data = SoManager.Instance.GetCharacterData<UnitData>(flag);
                m_textHeader.text = data.Name;
                m_str.Append($"STR: {data.STR}\nDEX: {data.DEX}\nINT: {data.INT}\nDAMAGE: {data.MinDamage}-{data.MaxDamage}\n{data.Description}");
                m_textDescription.text = m_str.ToString();
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

            var data = SoManager.Instance.GetCharacterData<UnitData>(m_selectedCharFlag);
            DataManager.Instance.CreatePlayer(data);

            SceneManager.Instance.LoadSceneAsync(((short)SceneFlags.StageAxe)).Forget();
        }

        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            SceneManager.Instance.LoadSceneAsync(((int)common.flags.SceneFlags.LoginScene)).Forget();
        }
        #endregion
    }
}