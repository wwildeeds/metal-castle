using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.pattern
{
    using Cysharp.Threading.Tasks;

    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T m_instance;
        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<T>();
                    if (m_instance == null)
                    {
                        var go = new GameObject();
                        m_instance = go.AddComponent<T>();
                        go.name = typeof(T).ToString();

                        //DontDestroyOnLoad(go);
                    }
                }

                return m_instance;
            }
        }

        protected bool destroyable;
        protected bool initialized;
        protected virtual void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this as T;

                if (destroyable == false)
                    DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                DestroyImmediate(this.gameObject);
            }
        }

        protected virtual async UniTask Start()
        {
            await UniTask.Yield();
        }

        public virtual async UniTask InitAsync()
        {
            await UniTask.Yield();
        }
    }
}
