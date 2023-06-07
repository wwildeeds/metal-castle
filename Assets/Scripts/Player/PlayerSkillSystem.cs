using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.data;
    using wwild.manager;

    public class PlayerSkillSystem : BaseSystem, ISkillSystem, IDisposable
    {
        PlayerSkillData m_skillData;

        public PlayerSkillSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public bool Initialized => throw new NotImplementedException();

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;

            IPlayerCtrl.GuiSystem.SkillPage.RegisterSkills(m_skillData.UniqueSkills.ToArray());
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