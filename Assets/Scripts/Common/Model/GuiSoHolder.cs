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
    public class GuiSoHolder : BaseSoHolder, IDisposable
    {
        [SerializeField]
        private string path_loginGuiData = "SO/LoginGuiData";
        [SerializeField]
        private string path_playerGuiData = "SO/PlayerGuiData";

        private LoginGuiData m_loginGuiData;
        private PlayerGuiData m_playerGuiData;

        public GuiSoHolder()
        {
            soHolder = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_loginGuiData = await Resources.LoadAsync(path_loginGuiData) as LoginGuiData;
            m_playerGuiData = await Resources.LoadAsync(path_playerGuiData) as PlayerGuiData;

            soHolder.Add(((short)GuiSoFlags.LoginGui), m_loginGuiData);
            soHolder.Add(((short)GuiSoFlags.PlayerGui), m_playerGuiData);
        }

        public T GetGuiSo<T>(GuiSoFlags flag) where T : ScriptableObject
        {
            if (soHolder.ContainsKey(((short)flag)))
            {
                return soHolder[((short)flag)] as T;
            }

            throw new NullReferenceException();
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_loginGuiData);
            Resources.UnloadAsset(m_playerGuiData);

            soHolder.Clear();
            soHolder = null;
        }
    }
}