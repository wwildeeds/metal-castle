using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.manager
{
    using Cysharp.Threading.Tasks;
    using wwild.pattern;
    using wwild.scriptableObjects;
    using wwild.scriptableObjects.data;
    using wwild.common.data;
    using wwild.common.itf;
    using wwild.common.model;

    public class GameManager : Singleton<GameManager>
    {
        private CharacterModel m_characterModel;
        private InGameGuiModel m_inGameGuiModel;

        public CharacterModel characterModel => m_characterModel;
        public InGameGuiModel inGameGuiModel => m_inGameGuiModel;

        protected override void Awake()
        {
            m_characterModel = new CharacterModel();
            m_inGameGuiModel = new InGameGuiModel();
        }

        protected override async UniTask Start()
        {
            await m_characterModel.InitAsync();
            await m_inGameGuiModel.InitAsync();
        }
    }
}