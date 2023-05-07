using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace wwild.ui.ingame
{
    using Cysharp.Threading.Tasks;
    public class InGamePage : BasePage, IDisposable
    {
        [SerializeField]
        private Button m_buttonPlayerInfo;
        [SerializeField]
        private Button m_buttonPlayerSkill;
        [SerializeField]
        private Button m_buttonPlayerInventory;
        [SerializeField]
        private Button m_buttonSetting;

        public override void Init()
        {
            base.Init();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
        }

        public void Dispose()
        {
        }

        #region button events
        private async UniTask OnButtonPlayerInfoClickAsync()
        {
            await UniTask.Yield();
        }
        #endregion
    }
}
