using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace wwild.common.model.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.data;

    [Serializable]
    public class HistoryPlayerModel : BaseModel, IDisposable
    {
        [SerializeField]
        private List<PlayerStateData> m_stateList;
        [SerializeField]
        private List<PlayerSkillData> m_skillList;
        [SerializeField]
        private List<PlayerInventoryData> m_inventoryList;

        public HistoryPlayerModel()
        {
            m_stateList = new List<PlayerStateData>();
            m_skillList = new List<PlayerSkillData>();
            m_inventoryList = new List<PlayerInventoryData>();
        }

        public void AddPlayerModel(PlayerModel model)
        {
            m_stateList.Add(model.StateData);
            m_skillList.Add(model.SkillData);
            m_inventoryList.Add(model.InventoryData);
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
