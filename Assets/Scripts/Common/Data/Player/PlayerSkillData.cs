using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace wwild.common.data
{
    using wwild.scriptableObjects;
    using wwild.common.flags;

    [Serializable]
    public class PlayerSkillData : IDisposable
    {
        [SerializeField]
        private List<BaseSkillData> m_skillList;
        public PlayerSkillData()
        {
        }

        public PlayerSkillData(SkillData[] data)
        {
            m_skillList = new List<BaseSkillData>();

            for (int i = 0; i < data.Length; i++)
            {
                var skill = new BaseSkillData(data[i]);
                m_skillList.Add(skill);
            }
        }

        public BaseSkillData GetSkillByName(string name)
        {
            var temp = m_skillList.Find(skill => skill.AnimName.Equals(name));
            return temp;
        }

        public BaseSkillData GetSkillByFlag(AnimClipFlags flag)
        {
            var temp = m_skillList.Find(skill => skill.AnimFlag.Equals(flag));
            return temp;
        }

        public void Dispose()
        {
        }
    }
}
