using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.data
{
    using wwild.scriptableObjects;
    [Serializable]
    public class BaseSkillData
    {
        [SerializeField]
        private string m_skillName;
        [SerializeField]
        private string m_skillDesc;
        [SerializeField]
        private float m_skillMinCooltime;
        [SerializeField]
        private float m_skillMaxCooltime;
        [SerializeField]
        private bool m_skillCoolDone;
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
        public float SkillCooltime => m_skillMinCooltime;
        public bool SkillCoolDone => m_skillCoolDone;
        public Sprite SkillIcon => m_skillIcon;


        public string AnimName => m_animName;
        public float AnimExitTime => m_animExistTime;
        public float[] AnimEventTimes => m_animEventTimes;

        public BaseSkillData()
        { }

        public BaseSkillData(SkillData data)
        {
            m_skillName = data.SkillName;
            m_skillDesc = data.SkillDesc;
            m_skillMinCooltime = m_skillMaxCooltime = data.SkillCooltime;
            m_skillIcon = data.SkillIcon;
            m_skillCoolDone = true;

            m_animName = data.AnimName;
            m_animExistTime = data.AnimExitTime;
            m_animEventTimes = data.AnimEventTimes;
        }
    }
}
