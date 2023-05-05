using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.pattern
{
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

        protected virtual void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                DestroyImmediate(this);
            }
        }
    }
}
