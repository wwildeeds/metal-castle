using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.manager
{
    using Cysharp.Threading.Tasks;
    using wwild.pattern;
    using wwild.common.model.so;
    using wwild.common.flags;

    public class SoManager : Singleton<SoManager>
    {
        [SerializeField]
        private CharacterModel m_characterModel;
        [SerializeField]
        private GuiModel m_guiModel;
        [SerializeField]
        private AnimModel m_animModel;
        [SerializeField]
        private SkillModel m_skillModel;

        public bool Initialized => initialized;

        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            m_characterModel = new CharacterModel();
            m_guiModel = new GuiModel();
            m_animModel = new AnimModel();
            m_skillModel = new SkillModel();

            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await m_characterModel.InitAsync();
            await m_guiModel.InitAsync();
            await m_animModel.InitAsync();
            await m_skillModel.InitAsync();

            initialized = true;
        }

        public T GetCharacterModel<T>(CharacterFlags flag) where T : ScriptableObject
        {
            return m_characterModel.GetCharacterData<T>(flag);
        }

        public T GetGuiModel<T>(GuiFlags flag) where T : ScriptableObject
        {
            return m_guiModel.GetGuiData<T>(flag);
        }

        public T GetAnimModel<T>(AnimScriptableObjFlags flag) where T : ScriptableObject
        {
            return m_animModel.GetAnimData<T>(flag);

        }

        public T GetSkillModel<T>(SkillModelFlags flag) where T : ScriptableObject
        {
            return m_skillModel.GetModel<T>(flag);
        }
    }
}
