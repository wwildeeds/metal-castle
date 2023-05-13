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

        public GuiModel()
        {
            modelStore = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_loginGuiData = await Resources.LoadAsync(path_loginGuiData) as LoginGuiData;
            m_playerGuiData = await Resources.LoadAsync(path_playerGuiData) as PlayerGuiData;

            modelStore.Add(((short)GuiFlags.LoginGui), m_loginGuiData);
            modelStore.Add(((short)GuiFlags.PlayerGui), m_playerGuiData);
        }

        public T GetGuiData<T>(GuiFlags flag) where T : ScriptableObject
        {
            if (modelStore.ContainsKey(((short)flag)))
            {
                return modelStore[((short)flag)] as T;
            }

            throw new NullReferenceException();
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_loginGuiData);
            Resources.UnloadAsset(m_playerGuiData);

            modelStore.Clear();
            modelStore = null;
        }
    }
}