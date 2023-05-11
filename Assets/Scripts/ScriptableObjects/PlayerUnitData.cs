using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    using wwild.common.flags;
    [CreateAssetMenu(fileName = "PlayerUnitData", menuName = "PlayerUnitData")]
    public class PlayerUnitData : UnitData
    {
        [SerializeField]
        private CharacterFlags m_flag;


        public CharacterFlags Flag => m_flag;

    }
}
