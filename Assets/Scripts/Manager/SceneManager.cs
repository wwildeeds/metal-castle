using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.manager
{
    using Cysharp.Threading.Tasks;
    using wwild.pattern;
    using wwild.common.model;
    using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
    
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField]
        private SceneModel m_sceneModel;

        private void Start()
        {
            m_sceneModel = new SceneModel();    
        }

        public async UniTask LoadSceneAsync(int idx)
        {
            AsyncOperation loadOperation = UnitySceneManager.LoadSceneAsync(idx, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            loadOperation.completed += async done =>
            {
                await UnitySceneManager.UnloadSceneAsync(((int)m_sceneModel.PreSceneFlag));

                m_sceneModel.SetSceneFlag(idx);
            };
            while (loadOperation.isDone == false)
            {
                //Debug.Log(loadOperation.progress.ToString("P"));

                if (loadOperation.progress >= 0.9f)
                {
                    loadOperation.allowSceneActivation = false;
                    break;
                }
                
                await UniTask.Yield();
            }

            loadOperation.allowSceneActivation = true;
        }
    }
}
