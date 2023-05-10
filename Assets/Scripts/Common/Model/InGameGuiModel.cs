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
        private PlayerGuiData m_playerGuiSO;

        public PlayerGuiData playerGuiSo => m_playerGuiSO;

        public InGameGuiModel()
        { }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_playerGuiSO = await Resources.LoadAsync<PlayerGuiData>(nameof(PlayerGuiData)) as PlayerGuiData;
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_playerGuiSO);

            m_playerGuiSO = null;
        }
    }
}
