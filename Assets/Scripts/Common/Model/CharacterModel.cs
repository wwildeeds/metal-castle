using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects.data;
    using wwild.common.flags;
    public class CharacterModel : IDisposable
    {
        private readonly string path_assassinSO = "AssassinDataSO";
        private readonly string path_dualSO = "DualDataSO";
        private readonly string path_katanaSO = "KatanaDataSO";
        private readonly string path_axeSO = "AxeDataSO";

        private UnitDataSO m_assassinDataSO;
        private UnitDataSO m_dualDataSO;
        private UnitDataSO m_katanaDataSO;
        private UnitDataSO m_axeDataSO;

        public CharacterModel()
        { }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();
            m_assassinDataSO = await Resources.LoadAsync(path_assassinSO) as UnitDataSO;
            m_dualDataSO = await Resources.LoadAsync(path_dualSO) as UnitDataSO;
            m_katanaDataSO = await Resources.LoadAsync(path_katanaSO) as UnitDataSO;
            m_axeDataSO = await Resources.LoadAsync(path_axeSO) as UnitDataSO;
        }

        public UnitDataSO GetCharacterData(CharacterFlags flag)
        {
            switch (flag)
            {
                case CharacterFlags.Assassin:
                    return m_assassinDataSO;

                case CharacterFlags.Dual:
                    return m_dualDataSO;

                case CharacterFlags.Katana:
                    return m_katanaDataSO;

                case CharacterFlags.Axe:
                    return m_axeDataSO;
            }
            return null;
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_assassinDataSO);
            Resources.UnloadAsset(m_dualDataSO);
            Resources.UnloadAsset(m_katanaDataSO);
            Resources.UnloadAsset(m_axeDataSO);
        }
    }
}
