using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace wwild.common.data
{
    using Cysharp.Threading.Tasks;
    using wwild.common.data;

    [Serializable]
    public class PlayerHistoryData : IDisposable
    {
        [SerializeField]
        private List<PlayerStateData> m_stateList;
        [SerializeField]
        private List<PlayerSkillData> m_skillList;
        [SerializeField]
        private List<PlayerInventoryData> m_inventoryList;

        public List<PlayerStateData> StateList => m_stateList;

        public PlayerHistoryData()
        {
            m_stateList = new List<PlayerStateData>();
            m_skillList = new List<PlayerSkillData>();
            m_inventoryList = new List<PlayerInventoryData>();
        }

        public void AddData(PlayerData model)
        {
            m_stateList.Add(model.StateData);
            m_skillList.Add(model.SkillData);
            m_inventoryList.Add(model.InventoryData);
        }

        public PlayerData GetData(int idx)
        {
            var state = m_stateList[idx];
            var skill = m_skillList[idx];
            //var inven = m_inventoryList[idx];

            var model = new PlayerData(state, skill, null);
            return model;
        }

        public void RemoveData(int idx)
        {
            m_stateList.RemoveAt(idx);
        }

        public override string ToString()
        {
            return $"player state count: {m_stateList.Count}";
        }

        public void Dispose()
        {
            m_stateList?.ForEach(val => val.Dispose());
            m_skillList?.ForEach(val => val.Dispose());
            m_inventoryList?.ForEach(val => val.Dispose());

            m_stateList.Clear();
            m_skillList.Clear();
            m_inventoryList.Clear();

            m_stateList = null;
            m_skillList = null;
            m_inventoryList = null;
        }
    }
}
