using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    public interface IBaseFSM : IDisposable
    {
        Action<string> EventPlayAnimation { get; }
        Action<string> EventChangeFSM { get; }
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }
}
