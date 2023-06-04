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
        private CharacterSoHolder m_characterSoHolder;
        [SerializeField]
        private GuiSoHolder m_guiSoHolder;
        [SerializeField]
        private AnimSoHolder m_animSoHolder;
        [SerializeField]
        private SkillSoHolder m_skillSoHolder;

        public bool Initialized => initialized;

        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            m_characterSoHolder = new CharacterSoHolder();
            m_guiSoHolder = new GuiSoHolder();
            m_animSoHolder = new AnimSoHolder();
            m_skillSoHolder = new SkillSoHolder();

            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await m_characterSoHolder.InitAsync();
            await m_guiSoHolder.InitAsync();
            await m_animSoHolder.InitAsync();
            await m_skillSoHolder.InitAsync();

            initialized = true;
        }

        public T GetCharacterSo<T>(CharacterFlags flag) where T : ScriptableObject
        {
            return m_characterSoHolder.GetCharacterSo<T>(flag);
        }

        public T GetGuiSo<T>(GuiSoFlags flag) where T : ScriptableObject
        {
            return m_guiSoHolder.GetGuiSo<T>(flag);
        }

        public T GetAnimSo<T>(AnimSoFlags flag) where T : ScriptableObject
        {
            return m_animSoHolder.GetAnimSo<T>(flag);

        }

        public T GetSkillSo<T>(SkillSoFlags flag) where T : ScriptableObject
        {
            return m_skillSoHolder.GetSkillSo<T>(flag);
        }
    }
}
