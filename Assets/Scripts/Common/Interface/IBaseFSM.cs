using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    using wwild.common.flags;
    public interface IBaseFSM : IDisposable
    {
        //string AnimName { get; }
        //int AnimID { get; }
        AnimClipFlags AnimFlag { get; }
        void OnEnter();
        void OnUpdate();
        void OnExit();
        void RegisterFsmSystem(IFSMSystem fsmSystem);
    }
}
