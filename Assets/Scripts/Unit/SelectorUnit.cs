using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.unit.newgame
{
    public interface ISelectorUnit
    {
        int InstanceID { get; }
        void ToUniqueState();
        void ToIdleState();
    }

    public class SelectorUnit : MonoBehaviour, ISelectorUnit
    {
        private Animator m_animator;

        public int InstanceID { get; private set; }

        public void ToIdleState()
        {
            m_animator.CrossFade("Idle", 0.175f);
        }

        public void ToUniqueState()
        {
            m_animator.CrossFade("Unique", 0.175f);
        }

        private void Start()
        {
            m_animator = this.GetComponent<Animator>();

            InstanceID = this.GetInstanceID();
        }
    }
}
