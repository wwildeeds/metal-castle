using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace wwild.common.data
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    using wwild.common.flags;

    [Serializable]
    public class PlayerSkillData : IDisposable
    {
        [SerializeField]
        private List<CharacterSkillData> m_defaultList;
        [SerializeField]
        private List<CharacterSkillData> m_uniqueList;

        public List<CharacterSkillData> DefaultSkills => m_defaultList;
        public List<CharacterSkillData> UniqueSkills => m_uniqueList;

        public PlayerSkillData()
        {
        }

        public PlayerSkillData(SkillSo[] defaultSkill, SkillSo[] uniqueSkill)
        {
            m_defaultList = new List<CharacterSkillData>();
            m_uniqueList = new List<CharacterSkillData>();

            for (int i = 0; i < defaultSkill.Length; i++)
            {
                var data = new CharacterSkillData(defaultSkill[i]);
                m_defaultList.Add(data);
            }

            for (int i = 0; i < uniqueSkill.Length; i++)
            {
                var data = new CharacterSkillData(uniqueSkill[i]);
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