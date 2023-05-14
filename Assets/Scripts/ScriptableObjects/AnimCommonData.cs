using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "AnimCommonData", menuName = "AnimCommonData")]
    public class AnimCommonData : ScriptableObject
    {
        [SerializeField]
        private string m_idle;
        [SerializeField]
        private string m_run;
        [SerializeField]
        private string m_dead;
        [SerializeField]
        private string m_guard;
        [SerializeField]
        private string m_attackA;
        [SerializeField]
        private string m_attackB;
        [SerializeField]
        private string m_attackC;
        [SerializeField]
        private string m_attackD;
        [SerializeField]
        private string m_skillA;
        [SerializeField]
        private string m_skillB;
        [SerializeField]
        private string m_skillC;
        [SerializeField]
        private string m_skillD;

        public string Idle => m_idle;
        public string Run => m_run;
        public string Dead => m_dead;
        public string Guard => m_guard;
        public string AttackA => m_attackA;
        public string AttackB => m_attackB;
        public string AttackC => m_attackC;
        public string AttackD => m_attackD;
        public string SkillA => m_skillA;
        public string SkillB => m_skillB;
        public string SkillC => m_skillC;
        public string SkillD => m_skillD;
    }
}