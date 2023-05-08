using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.unit.newgame
{
    using wwild.common.flags;

    public interface ISelectorUnit
    {
        int InstanceID { get; }
        //string UnitInfo { get; }
        //string UnitDesc { get; }
        CharacterFlags UnitFlag { get; }
        void ToUniqueState();
        void ToIdleState();
    }

    public class SelectorUnit : MonoBehaviour, ISelectorUnit
    {
        private Animator m_animator;

        [Tooltip("class info"), SerializeField]
        private string m_classInfo;
        [Tooltip("class desc"), SerializeField]
        private string m_classDesc;
        [Tooltip("character flag"), SerializeField]
        private CharacterFlags m_characterFlag;

        public int InstanceID { get; private set; }

        //public string UnitInfo => m_classInfo;

        //public string UnitDesc => m_classDesc;

        public CharacterFlags UnitFlag => m_characterFlag;

        public void ToIdleState()
        {
            m_animator.CrossFade("Idle", 0.075f);
        }

        public void ToUniqueState()
        {
            m_animator.CrossFade("Unique", 0.075f);
        }

        private void Start()
        {
            m_animator = this.GetComponent<Animator>();

            InstanceID = this.GetInstanceID();
        }
    }
}
