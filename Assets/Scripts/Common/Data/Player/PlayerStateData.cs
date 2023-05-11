using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.data
{
    using wwild.common.itf;
    using wwild.common.flags;
    using wwild.scriptableObjects;

    [Serializable]
    public class PlayerStateData : BaseStateData, IPlayerStateData, IDisposable
    {
        [SerializeField]
        private CharacterFlags m_characterflag;

        public CharacterFlags CharacterFlag => m_characterflag;
        public PlayerStateData()
        {
        }

        public PlayerStateData(PlayerUnitData data) : base(data)
        {
            m_characterflag = data.Flag;
        }
        

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
