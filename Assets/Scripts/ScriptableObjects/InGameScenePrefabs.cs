using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "InGameScenePrefabs", menuName = "InGameScenePrefabs")]
    public class InGameScenePrefabs : ScriptableObject
    {
        [SerializeField]
        private string m_inGamePage;
        [SerializeField]
        private string m_playerInfoPage;

        public string InGamePage => m_inGamePage;
        public string PlayerInfoPage => m_playerInfoPage;
    }
}
