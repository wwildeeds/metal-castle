using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace wwild.setting
{
    using Cysharp.Threading.Tasks;

    public class RenderSetting : MonoBehaviour
    {
        public float speed;
        private float rotate;

        private CancellationToken m_destroyToken;
        
        private void Start()
        {
            m_destroyToken = this.GetCancellationTokenOnDestroy();
            RotateSkyboxAsync().ToCancellationToken(m_destroyToken);
        }

        private async UniTask RotateSkyboxAsync()
        {
            await UniTask.Yield();

            while(true)
            {
                rotate += speed * Time.deltaTime;
                RenderSettings.skybox?.SetFloat("_Rotation", rotate);
                await UniTask.Yield();
            }
        }
    }
}