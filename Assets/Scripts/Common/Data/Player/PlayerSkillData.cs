using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace wwild.common.data
{
    [Serializable]
    public class PlayerSkillData : IDisposable
    {
        private List<BaseSkillData> m_skillList;
        public PlayerSkillData()
        {
            m_skillList = new List<BaseSkillData>();
        }

        public BaseSkillData GetSkill(string name)
        {
            var temp = m_skillList.Find(skill => skill.AnimName.Equals(name));
            return temp;
        }

        public void Dispose()
        {
        }
    }
}
