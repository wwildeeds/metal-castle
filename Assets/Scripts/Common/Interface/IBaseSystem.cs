using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    using wwild.controller;
    public interface IBaseSystem : IDisposable
    {
        bool Initialized { get; }

        void UpdateSystem();
    }
}