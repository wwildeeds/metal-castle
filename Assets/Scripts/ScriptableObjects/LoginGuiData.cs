using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "LoginGuiData", menuName = "LoginGuiData")]
    public class LoginGuiData : ScriptableObject
    {
        [SerializeField]
        private string m_newgamePage;
        [SerializeField]
        private string m_historyPage;
        [SerializeField]
        private string m_settingPage;

        [SerializeField]
        private GameObject m_historyButton;

        public string NewgamePage { get { return m_newgamePage; } }
        public string HistoryPage { get { return m_historyPage; } }
        public string SettingPage { get { return m_settingPage; } }
        public GameObject HistoryButton { get { return m_historyButton; } }
    }
}
