using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wwild.ui.login
{
    using wwild.ui;
    using wwild.common.itf;
    public class LoginPage : BasePage, IContentPage
    {
        public int InstanceID { get; private set; }

        [Tooltip("new game button component"), SerializeField]
        private Button m_btnNewgame;
        [Tooltip("option button component"), SerializeField]
        private Button m_btnOption;
        [Tooltip("exist button component"), SerializeField]
        private Button m_btnExist;

        public override void Init()
        {
            InstanceID = this.GetInstanceID();

            m_containers = new Dictionary<string, IContentPage>();
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
        }

        
    }
}