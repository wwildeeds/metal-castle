using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName ="AssassinSkillData", menuName ="AssassinSkillData")]
    public class AssassinSkillData : ScriptableObject
    {
        [SerializeField]
        private SkillData[] m_skillList;

        public SkillData[] SkillList => m_skillList;
    }
}