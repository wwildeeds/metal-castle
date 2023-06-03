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
        private UnitStateFlags m_stateFlag;
        [SerializeField]
        private CharacterFlags m_characterFlag;
        [SerializeField]
        private SceneFlags m_sceneFlag;

        public CharacterFlags CharacterFlag => m_characterFlag;
        public UnitStateFlags StateFlag => m_stateFlag;
        public SceneFlags SceneFlag => m_sceneFlag;

        public PlayerStateData()
        {
        }

        public PlayerStateData(PlayerUnitData data) : base(data)
        {
            m_characterFlag = data.CharacterFlag;
            m_sceneFlag = data.SceneFlag;

            m_stateFlag = UnitStateFlags.Normal;
        }

        public void ChangePlayerState(UnitStateFlags flag)
        {
            m_stateFlag = flag;
        }

        public override string ToString()
        {
            var info = $"Character type: {CharacterFlag}\nLevel: {Level}\nSTR: {STR}\nHP: {MinHealth}-{MaxHealth}\nEnerge: {MinMana}-{MaxMana}" +
                       $"\nDEX: {DEX}\nINT: {INT}" +
                       $"\nDMG: {MinDamage}-{MaxDamage}\nDFC: {MinDefence}-{MaxDefence}\nStage: {SceneFlag}" +
                       $"\nDesc: {Desc}";
            return info;
        }

        public void Dispose()
        {
        }
    }
}
