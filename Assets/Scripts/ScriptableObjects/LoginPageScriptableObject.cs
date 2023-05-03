using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects
{
    [CreateAssetMenu(fileName = "LoginPageScriptableObject", menuName = "LoginPageScriptableObject")]
    public class LoginPageScriptableObject : ScriptableObject
    {
        public string NewgamePage;
        public string OptionPage;
    }
}
