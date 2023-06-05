using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "SkillListSO", menuName = "SkillListSO")]
    public class SkillListSO : ScriptableObject
    {
        [SerializeField]
        private SkillData[] m_defaultSkills;
        [SerializeField]
        private SkillData[] m_uniqueSkills;

        public SkillData[] DefaultSkills => m_defaultSkills;
        public SkillData[] UniqueSkills => m_uniqueSkills;
    }
}
