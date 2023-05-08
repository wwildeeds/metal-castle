using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects.data;
    public class CharacterModel : IDisposable
    {
        private AssassinData m_assassinDataSO;

        public CharacterModel()
        { }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_assassinDataSO = await Resources.LoadAsync<AssassinData>(nameof(AssassinData)) as AssassinData;
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_assassinDataSO);
            m_assassinDataSO = null;
        }
    }
}
