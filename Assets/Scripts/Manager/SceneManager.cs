using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

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

        public async UniTask LoadSceneAsync(int idx, Func<GameObject[]> callback = null)
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

                if (callback != null)
                {
                    var objs = callback.Invoke();
                    for (int i = 0; i < objs.Length; i++)
                    {
                        var scene = UnitySceneManager.GetSceneByName(m_sceneModel.GetSceneName(idx));
                        UnitySceneManager.MoveGameObjectToScene(objs[i], scene);
                    }
                }

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

            newScene.allowSceneActivation = true;
        }
    }
}