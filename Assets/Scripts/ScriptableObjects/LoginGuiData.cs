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
        private string m_optionPage;

        public string NewgamePage { get { return m_newgamePage; } }
        public string OptionPage { get { return m_optionPage; } }
    }
}
