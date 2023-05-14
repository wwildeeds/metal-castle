using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.data
{
    using wwild.common.flags;
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
        private AnimClipFlags m_animFlag;
        [SerializeField]
        private int m_animFrameLength;
        [SerializeField]
        private int m_animTranslationFrame;
        [SerializeField]
        private int[] m_animEventFrames;
        [SerializeField]
        private float m_animExistTime;
        

        public string SkillName => m_skillName;
        public string SkillDesc => m_skillDesc;
        public float SkillCooltime => m_skillMinCooltime;
        public bool SkillCoolDone => m_skillCoolDone;
        public Sprite SkillIcon => m_skillIcon;


        public string AnimName => m_animName;
        public AnimClipFlags AnimFlag => m_animFlag;
        public int AnimFrameLength => m_animFrameLength;
        public int AnimTranslationFrame => m_animTranslationFrame;
        public int[] AnimEventFrames => m_animEventFrames;
        public float AnimExitTime => m_animExistTime;

        public BaseSkillData()
        { }

        public BaseSkillData(SkillData data)
        {
            m_skillName = data.SkillName;
            m_skillDesc = data.SkillDesc;
            m_skillMinCooltime = m_skillMaxCooltime = data.SkillCooltime;
            m_skillIcon = data.SkillIcon;
            m_skillCoolDone = true;

            m_animName = data.AnimFlag.ToString();
            m_animFlag = data.AnimFlag;
            m_animFrameLength = data.AnimFrameLength;
            m_animTranslationFrame = data.AnimTranslationFrame;
            m_animExistTime = data.AnimExitTime;
            m_animEventFrames = data.AnimEventFrames;
        }
    }
}
