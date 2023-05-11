using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace wwild.ui.button
{
    using wwild.common.itf;

    [RequireComponent(typeof(Button))]
    //[RequireComponent(typeof(GridLayoutGroup))]
    public class HistoryButton : MonoBehaviour, IHistoryButton
    {
        [SerializeField]
        private Text m_textName;
        [SerializeField]
        private Text m_textId;
        [SerializeField]
        private Text m_textFlag;
        [SerializeField]
        private Text m_textLevel;

        public void SetData(string name, string id, string characterFlag, string level)
        {
            m_textName.text = name;
            m_textId.text = id;
            m_textFlag.text = characterFlag;
            m_textLevel.text = level;
        }

        public void Dispose()
        {
        }
    }
}
