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

        public bool Initialized => initialized;

        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            m_characterModel = new CharacterModel();
            m_guiModel = new GuiModel();
            m_animModel = new AnimModel();

            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await m_characterModel.InitAsync();
            await m_guiModel.InitAsync();
            await m_animModel.InitAsync();

            initialized = true;
        }

        public T GetCharacterData<T>(CharacterFlags flag) where T : ScriptableObject
        {
            return m_characterModel.GetCharacterData<T>(flag);
        }

        public T GetGuiData<T>(GuiFlags flag) where T : ScriptableObject
        {
            return m_guiModel.GetGuiData<T>(flag);
        }

        public T GetAnimData<T>(AnimScriptableObjFlags flag) where T : ScriptableObject
        {
            return m_animModel.GetAnimData<T>(flag);

        }
    }
}