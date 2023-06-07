using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "SkillListSO", menuName = "SkillListSO")]
    public class SkillListSO : ScriptableObject
    {
        [SerializeField]
        private SkillSo[] m_defaultSkills;
        [SerializeField]
        private SkillSo[] m_uniqueSkills;

        public SkillSo[] DefaultSkills => m_defaultSkills;
        public SkillSo[] UniqueSkills => m_uniqueSkills;
    }
}
