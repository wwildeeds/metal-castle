using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    using wwild.scriptableObjects;
    public interface IPlayerStateData
    {
        string StateInfo { get; }
        void LevelUp();
    }
}
