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
        private CharacterFlags m_selectedCharSoFlag;

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
                    m_selectedCharSoFlag = CharacterFlags.None;
                    m_description.SetActive(false);
                    return;
                }

                m_str.Clear();
                m_selectedCharSoFlag = flag;

                var data = SoManager.Instance.GetCharacterSo<UnitData>(flag);
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
            await UniTask.WaitUntil(() => DataManager.Instance.Initialized && SoManager.Instance.Initialized);

            var statData = SoManager.Instance.GetCharacterSo<PlayerUnitData>(m_selectedCharSoFlag);

            SkillListSO tempSO = null;
            SkillData[] defaultSkills = null;
            SkillData[] uniqueSkills = null;
            switch (statData.CharacterFlag)
            {
                case CharacterFlags.Assassin:
                    tempSO = SoManager.Instance.GetSkillSo<SkillListSO>(SkillSoFlags.AssassinSkillModel);
                    break;

                case CharacterFlags.Axe:
                    tempSO = SoManager.Instance.GetSkillSo<SkillListSO>(SkillSoFlags.AxeSkillModel);
                    break;

                case CharacterFlags.Dual:
                    tempSO = SoManager.Instance.GetSkillSo<SkillListSO>(SkillSoFlags.DualSkillModel);
                    break;

                case CharacterFlags.Katana:
                    tempSO = SoManager.Instance.GetSkillSo<SkillListSO>(SkillSoFlags.KatanaSkillModel);
                    break;
            }

            if (tempSO == null) throw new NullReferenceException("not found skill scriptable object asset");

            defaultSkills = tempSO.DefaultSkills;
            uniqueSkills = tempSO.UniqueSkills;


            await DataManager.Instance.PlayerStore.CreatePlayerDataAsync(statData, defaultSkills, uniqueSkills);

            SceneManager.Instance.LoadSceneAsync(((short)SceneFlags.StageAxe), () => 
            {
                var goList = new List<GameObject>();
                if (GameManager.Instance.PlayerPool.HasPlayer)
                {
                }
                else
                {
                    GameManager.Instance.PlayerPool.CreatePlayer();
                }
                if (GameManager.Instance.PlayerPool.HasCamera)
                { }
                else
                {
                    GameManager.Instance.PlayerPool.CreateCamera();
                }

                goList.Add(GameManager.Instance.PlayerPool.MyPlayer);
                goList.Add(GameManager.Instance.PlayerPool.MyCamera);
                return goList.ToArray();

            }).Forget();
        }

        private async UniTask OnButtonCancelClickAsync()
        {
            await UniTask.Yield();

            Dispose();

            SceneManager.Instance.LoadSceneAsync(((int)SceneFlags.LoginScene)).Forget();
        }
        #endregion
    }
}