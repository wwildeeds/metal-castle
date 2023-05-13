using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.fsm
{
    using wwild.common.itf;
    using wwild.scriptableObjects;
    public class BaseFSM : IBaseFSM, IDisposable
    {
        private string m_animName;
        private float m_animExitTime;
        private float[] m_animEventTimes;

        protected string AnimName => m_animName;
        protected float AnimExitTime => m_animExitTime;
        protected float[] AnimEventTimes => m_animEventTimes;

        public Action<string> EventPlayAnimation { get; private set; }
        public Action<string> EventChangeFSM { get; private set; }

        public BaseFSM()
        { }
        public BaseFSM(SkillData data)
        {
            m_animName = data.AnimName;
            m_animExitTime = data.AnimExitTime;
            m_animEventTimes = data.AnimEventTimes;
        }

        public virtual void OnEnter()
        { }

        public virtual void OnUpdate()
        { }

        public virtual void OnExit()
        { }

        public void Dispose()
        {
            EventPlayAnimation = null;
            EventChangeFSM = null;
        }
    }
}
