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
    public class GuiModel : BaseModel, IDisposable
    {
        [SerializeField]
        private string path_loginGuiData = "SO/LoginGuiData";
        [SerializeField]
        private string path_playerGuiData = "SO/PlayerGuiData";

        private LoginGuiData m_loginGuiData;
        private PlayerGuiData m_playerGuiData;

        private Dictionary<short, ScriptableObject> m_dataStore;

        public GuiModel()
        {
            m_dataStore = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_loginGuiData = await Resources.LoadAsync(path_loginGuiData) as LoginGuiData;
            m_playerGuiData = await Resources.LoadAsync(path_playerGuiData) as PlayerGuiData;

            m_dataStore.Add(((short)GuiFlags.LoginGui), m_loginGuiData);
            m_dataStore.Add(((short)GuiFlags.PlayerGui), m_playerGuiData);
        }

        public T GetGuiData<T>(GuiFlags flag) where T : ScriptableObject
        {
            if (m_dataStore.ContainsKey(((short)flag)))
            {
                return m_dataStore[((short)flag)] as T;
            }

            throw new NullReferenceException();
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_loginGuiData);
            Resources.UnloadAsset(m_playerGuiData);

            m_dataStore.Clear();
            m_dataStore = null;
        }
    }
}