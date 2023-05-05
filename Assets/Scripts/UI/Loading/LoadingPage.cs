using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Threading;
using System;

namespace wwild.ui.loading
{
    using Cysharp.Threading.Tasks;
    public class LoadingPage : MonoBehaviour
    {
        [SerializeField]
        private Text m_textDot;

        private CancellationToken m_token;
        private StringBuilder m_str;
        private void Start()
        {
            m_token = this.GetCancellationTokenOnDestroy();

            m_str = new StringBuilder();

            AnimatingAsync().Forget();
        }

        private async UniTask AnimatingAsync()
        {

            while (true)
            {
                if (m_str.Length.Equals(3)) m_str.Clear();
                else m_str.Append(".");
                m_textDot.text = m_str.ToString();
                await UniTask.Delay(TimeSpan.FromSeconds(1), false, PlayerLoopTiming.Update, m_token);
            }
        }

    }
}
