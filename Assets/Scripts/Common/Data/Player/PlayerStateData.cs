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
    public class PlayerStateData : BaseStateData, IDisposable
    {
        [SerializeField]
        private CharacterFlags m_characterFlag;
        [SerializeField]
        private SceneFlags m_sceneFlag;
        public CharacterFlags CharacterFlag => m_characterFlag;
        public SceneFlags SceneFlag => m_sceneFlag;

        public PlayerStateData()
        {
        }

        public PlayerStateData(PlayerUnitData data) : base(data)
        {
            m_characterFlag = data.CharacterFlag;
            m_sceneFlag = data.SceneFlag;
        }

        public override string ToString()
        {
            var info = $"Character type: {CharacterFlag}\nLevel: {Level}\nSTR: {STR}\nDEX: {DEX}\nINT: {INT}" +
                       $"\nDMG: {MinDamage}-{MaxDamage}\nDFC: {MinDefence}-{MaxDefence}\nStage: {SceneFlag}" +
                       $"\nDesc: {Desc}";
            return info;
        }

        public void Dispose()
        {
        }
    }
}