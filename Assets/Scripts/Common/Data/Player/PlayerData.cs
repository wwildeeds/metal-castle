using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.data
{
    using wwild.common.itf;
    using wwild.scriptableObjects;

    [Serializable]
    public class PlayerData
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

        public PlayerData()
        { }

        public PlayerData(PlayerUnitData data)
        {
            m_stateData = new PlayerStateData(data);
            m_skillData = new PlayerSkillData();
            m_inventoryData = new PlayerInventoryData();
        }

        public PlayerData(PlayerStateData state, PlayerSkillData skill, PlayerInventoryData inven)
        {
            m_stateData = state;
            m_skillData = skill;
            m_inventoryData = inven;
        }

        public void Dispose()
        {
            StateData?.Dispose();
            SkillData?.Dispose();
            InventoryData?.Dispose();
        }

        
    }
}
