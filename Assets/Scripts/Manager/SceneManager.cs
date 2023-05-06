using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.manager
{
    using Cysharp.Threading.Tasks;
    using wwild.pattern;
    using wwild.common.model;
    using wwild.common.flags;
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
            AsyncOperation loadingScene = UnitySceneManager.LoadSceneAsync(((int)SceneFlags.LoadingScene), UnityEngine.SceneManagement.LoadSceneMode.Additive);
            loadingScene.completed += async done =>
            {
                await UnitySceneManager.UnloadSceneAsync(((int)m_sceneModel.PreSceneFlag));
            };

            await UniTask.WaitUntil(() => loadingScene.progress >= 0.9f);
            await UniTask.Delay(TimeSpan.FromSeconds(2));

            AsyncOperation newScene = UnitySceneManager.LoadSceneAsync(idx, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            newScene.completed += async done =>
            { 
                Debug.Log("do something");
                await UnitySceneManager.UnloadSceneAsync(((int)SceneFlags.LoadingScene));
                m_sceneModel.SetSceneFlag(idx);
            };

            while (newScene.isDone == false)
            {
                if (newScene.progress >= 0.9f)
                {
                    newScene.allowSceneActivation = false;
                    break;
                }
            }
            Debug.Log($"is done {newScene.isDone}");
            newScene.allowSceneActivation = true;

        }
    }
}
