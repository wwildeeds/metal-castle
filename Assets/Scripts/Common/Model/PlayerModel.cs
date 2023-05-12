using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.model.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.data;
    using wwild.scriptableObjects;
    [Serializable]
    public class PlayerModel : BaseModel, IDisposable
    {
        [SerializeField]
        private PlayerStateData m_stateData;
        [SerializeField]
        private PlayerSkillData m_skillData;
        [SerializeField]
        private PlayerInventoryData m_inventoryData;

        public PlayerStateData StateData => m_stateData;
        public PlayerSkillData SkillData => m_skillData;
        public PlayerInventoryData InventoryData => m_inventoryData;

        public PlayerModel()
        { }

        public void Set(PlayerStateData state, PlayerSkillData skill, PlayerInventoryData inven)
        {
            m_stateData = state;
            m_skillData = skill;
            m_inventoryData = inven;
        }

        public void Create(PlayerUnitData data)
        {
            m_stateData = new PlayerStateData(data);
        }

        public void Dispose()
        {
            m_stateData?.Dispose();
            m_skillData?.Dispose();
            m_inventoryData?.Dispose();
        }
    }
}