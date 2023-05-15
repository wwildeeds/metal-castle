using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "SkillListSO", menuName = "SkillListSO")]
    public class SkillListSO : ScriptableObject
    {
        [SerializeField]
        private SkillData[] m_skillList;

        public SkillData[] SkillList => m_skillList;
    }
}
