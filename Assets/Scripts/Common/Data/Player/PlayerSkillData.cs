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
        private List<BaseSkillData> m_defaultList;
        [SerializeField]
        private List<BaseSkillData> m_uniqueList;
        public PlayerSkillData()
        {
        }

        public PlayerSkillData(SkillData[] data)
        {
            m_uniqueList = new List<BaseSkillData>();

            for (int i = 0; i < data.Length; i++)
            {
                var skill = new BaseSkillData(data[i]);
                m_uniqueList.Add(skill);
            }
        }

        public PlayerSkillData(SkillData[] defaultSkill, SkillData[] uniqueSkill)
        {
            m_defaultList = new List<BaseSkillData>();
            m_uniqueList = new List<BaseSkillData>();

            for (int i = 0; i < defaultSkill.Length; i++)
            {
                var data = new BaseSkillData(defaultSkill[i]);
                m_defaultList.Add(data);
            }

            for (int i = 0; i < uniqueSkill.Length; i++)
            {
                var data = new BaseSkillData(uniqueSkill[i]);
                m_uniqueList.Add(data);
            }

        }

        public BaseSkillData GetSkillByName(string name)
        {
            var temp = m_uniqueList.Find(skill => skill.AnimName.Equals(name));
            return temp;
        }

        public BaseSkillData GetUniqueSkillByFlag(AnimClipFlags flag)
        {
            var temp = m_uniqueList.Find(skill => skill.AnimFlag.Equals(flag));
            return temp;
        }

        public BaseSkillData GetDefaultSkillByFlag(AnimClipFlags flag)
        {
            var temp = m_defaultList.Find(skill => skill.AnimFlag.Equals(flag));
            return temp;
        }

        public void Dispose()
        {
        }
    }
}
