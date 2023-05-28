using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    using Cysharp.Threading.Tasks;
    using wwild.controller;
    public interface IBaseSystem : IDisposable
    {
        bool Initialized { get; }
        UniTask InitAsync();
        void UpdateSystem();
        void LateUpdateSystem();
    }
}