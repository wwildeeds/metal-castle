using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "SkillData")]
    public class SkillData : ScriptableObject
    {
        [SerializeField]
        private string m_skillName;
        [SerializeField]
        private string m_skillDesc;
        [SerializeField]
        private float m_skillCooltime;
        [SerializeField]
        private Sprite m_skillIcon;

        [SerializeField]
        private string m_animName;
        [SerializeField]
        private float m_animExistTime;
        [SerializeField]
        private float[] m_animEventTimes;

        public string SkillName => m_skillName;
        public string SkillDesc => m_skillDesc;
        public float SkillCooltime => m_skillCooltime;
        public Sprite SkillIcon => m_skillIcon;
        public string AnimName => m_animName;
        public float AnimExitTime => m_animExistTime;
        public float[] AnimEventTimes => m_animEventTimes;
    }
}