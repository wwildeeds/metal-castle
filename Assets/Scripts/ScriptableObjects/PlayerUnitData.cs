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
        private CharacterFlags m_characterflag;
        [SerializeField]
        private SceneFlags m_sceneFlag;

        public CharacterFlags CharacterFlag => m_characterflag;
        public SceneFlags SceneFlag => m_sceneFlag;

    }
}
