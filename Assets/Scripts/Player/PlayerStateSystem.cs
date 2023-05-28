using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.flags;
    using wwild.common.itf;
    using wwild.common.data;
    using wwild.manager;

    public class PlayerStateSystem : BaseSystem, IStateSystem
    {
        private PlayerData m_playerData;

        public UnitStateFlags CurStateFlag => m_playerData.StateData.StateFlag;

        public bool Initialized { get; private set; }

        public PlayerStateSystem()
        { }

        public PlayerStateSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public async UniTask InitAsync()
        {
            await UniTask.WaitUntil(() => DataManager.Instance.Initialized);
            m_playerData = DataManager.Instance.PlayerStore.PlayerData;

            Initialized = true;
        }

        public void UpdateSystem()
        {
        }

        public void LateUpdateSystem()
        {
        }

        public void Dispose()
        {
        }
    }
}
