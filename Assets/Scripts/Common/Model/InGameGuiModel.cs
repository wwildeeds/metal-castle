using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    public class InGameGuiModel : IDisposable
    {
        private PlayerGuiSO m_playerGuiSO;

        public PlayerGuiSO playerGuiSo => m_playerGuiSO;

        public InGameGuiModel()
        { }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_playerGuiSO = await Resources.LoadAsync<PlayerGuiSO>(nameof(PlayerGuiSO)) as PlayerGuiSO;
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_playerGuiSO);

            m_playerGuiSO = null;
        }
    }
}
