using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model.so
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    using wwild.common.flags;
    [Serializable]
    public class CharacterModel : BaseModel, IDisposable
    {
        [Header("Character Scriptable Object Path")]
        [SerializeField]
        private string path_assassinData = "SO/AssassinData";
        [SerializeField]
        private string path_dualData = "SO/DualData";
        [SerializeField]
        private string path_katanaData = "SO/KatanaData";
        [SerializeField]
        private string path_axeData = "SO/AxeData";

        private UnitData m_assassinData;
        private UnitData m_dualData;
        private UnitData m_katanaData;
        private UnitData m_axeData;

        //private Dictionary<short, ScriptableObject> m_dataStore;

        public CharacterModel()
        {
            modelStore = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();
            m_assassinData = await Resources.LoadAsync(path_assassinData) as UnitData;
            m_dualData = await Resources.LoadAsync(path_dualData) as UnitData;
            m_katanaData = await Resources.LoadAsync(path_katanaData) as UnitData;
            m_axeData = await Resources.LoadAsync(path_axeData) as UnitData;

            modelStore.Add(((short)CharacterFlags.Assassin), m_assassinData);
            modelStore.Add(((short)CharacterFlags.Dual), m_dualData);
            modelStore.Add(((short)CharacterFlags.Katana), m_katanaData);
            modelStore.Add(((short)CharacterFlags.Axe), m_axeData);
        }

        public T GetCharacterData<T>(CharacterFlags flag) where T : ScriptableObject
        {
            if (modelStore.ContainsKey(((short)flag)))
                return modelStore[((short)flag)] as T;
            throw new NullReferenceException("not found character data");
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_assassinData);
            Resources.UnloadAsset(m_dualData);
            Resources.UnloadAsset(m_katanaData);
            Resources.UnloadAsset(m_axeData);

            modelStore.Clear();
            modelStore = null;
        }
    }
}
