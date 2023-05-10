using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu( fileName = "PlayerGuiData", menuName = "PlayerGuiData")]
    public class PlayerGuiData : ScriptableObject
    {
        [SerializeField]
        private string m_inGamePage;
        [SerializeField]
        private string m_playerInfoPage;
        [SerializeField]
        private string m_playerSkillPage;
        [SerializeField]
        private string m_playerInventoryPage;

        public string InGamePage => m_inGamePage;
        public string PlayerInfoPage => m_playerInfoPage;
        public string PlayerSkillPage => m_playerSkillPage;
        public string PlayerInventoryPage => m_playerInventoryPage;
    }
}
