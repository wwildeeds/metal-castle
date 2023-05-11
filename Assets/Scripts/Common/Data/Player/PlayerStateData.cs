using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.data
{
    using wwild.common.itf;
    using wwild.scriptableObjects;

    [Serializable]
    public class PlayerStateData : BaseStateData, IPlayerStateData, IDisposable
    {
        public PlayerStateData()
        {
        }

        public PlayerStateData(UnitData data) : base(data)
        { }

        

        public void Init()
        {
        }

        public void LevelUp()
        {
        }

        public void Dispose()
        {
        }
    }
}
