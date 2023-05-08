using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    using wwild.scriptableObjects.data;
    public interface IPlayerStateData
    {
        public void Init();
        public void LevelUp();
    }
}
