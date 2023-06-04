using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    using wwild.common.flags;

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
        private AnimClipFlags m_animFlag;
        [SerializeField]
        private int m_animFrameLength;
        [SerializeField]
        private int m_animTranslationFrame;
        [SerializeField]
        private int[] m_animEventFrames;
        [SerializeField]
        private float m_animExistTime = 0.99f;
        

        public string SkillName => m_skillName;
        public string SkillDesc => m_skillDesc;
        public float SkillCooltime => m_skillCooltime;
        public Sprite SkillIcon => m_skillIcon;


        public AnimClipFlags AnimFlag => m_animFlag;
        public int AnimFrameLength => m_animFrameLength;
        public int AnimTranslationFrame => m_animTranslationFrame;
        public int[] AnimEventFrames => m_animEventFrames;
        public float AnimExitTime => m_animExistTime;
    }
}