using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace wwild.ui.button
{
    using System;
    using wwild.common.itf;

    [RequireComponent(typeof(Button))]
    public class HistoryButton : MonoBehaviour, IHistoryButton
    {
        [SerializeField]
        private Button m_buttonHistory;
        [SerializeField]
        private Text m_textName;
        [SerializeField]
        private Text m_textId;
        [SerializeField]
        private Text m_textFlag;
        [SerializeField]
        private Text m_textLevel;

        public int Index => this.transform.GetSiblingIndex();

        public event Action OnSelected;

        private void Start()
        {
            m_buttonHistory.onClick.RemoveAllListeners();
            m_buttonHistory.onClick.AddListener(() => OnSelected?.Invoke());
        }

        public void SetData(string name, string id, string characterFlag, string level)
        {
            m_textName.text = name;
            m_textId.text = id;
            m_textFlag.text = characterFlag;
            m_textLevel.text = level;
        }

        public void Dispose()
        {
            OnSelected = null;

            DestroyImmediate(this.gameObject);
        }

    }
}
