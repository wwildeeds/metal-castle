using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace wwild.common.fsm
{
    using wwild.common.itf;
    using wwild.common.data;
    using wwild.common.flags;
    using wwild.scriptableObjects;
    public class BaseFSM : IBaseFSM, IDisposable
    {
        public AnimClipFlags AnimFlag { get; private set; }

        protected float AnimExitTime { get; private set; }
        protected float AnimTranslationTime { get; private set; }
        protected float[] AnimEventTimes { get; private set; }
        protected bool[] AnimEventToggles { get; private set; }

        protected float FrameToTime => 1 / 30;
        protected float EventTimer { get; set; }

        protected IFSMSystem IFsmSystem { get; private set; }

        public BaseFSM()
        { }
        public BaseFSM(BaseSkillData data)
        {
            AnimFlag = data.AnimFlag;
            AnimTranslationTime = FrameToTime * data.AnimTranslationFrame;
            AnimExitTime = FrameToTime * data.AnimExitTime;
            if (data.AnimEventFrames != null)
            {
                AnimEventTimes = new float[data.AnimEventFrames.Length];
                for (int i = 0; i < data.AnimEventFrames.Length; i++)
                {
                    AnimEventTimes[i] = FrameToTime * data.AnimEventFrames[i];
                }

                AnimEventToggles = new bool[AnimEventTimes.Length];
            }
        }

        public virtual void OnEnter()
        { }

        public virtual void OnUpdate()
        { }

        public virtual void OnExit()
        {
            EventTimer = 0f;

            if (AnimEventToggles == null) return;

            for (int i = 0; i < AnimEventToggles.Length; i++)
            {
                AnimEventToggles[i] = false;
            }
        }

        public void RegisterFsmSystem(IFSMSystem fsmSystem)
        {
            IFsmSystem = fsmSystem;
        }

        public void Dispose()
        {
        }

    }
}