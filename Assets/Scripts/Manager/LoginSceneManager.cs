using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.manager
{
    using wwild.pattern;
    using wwild.scriptableObjects;

    public class LoginSceneManager : Singleton<LoginSceneManager>
    {
        [SerializeField]
        private LoginScenePrefabs m_scenePrefabs;

        public LoginScenePrefabs ScenePrefabs { get { return m_scenePrefabs; } }

        protected override void Awake()
        {
            base.Awake();

            m_scenePrefabs = Resources.Load<LoginScenePrefabs>(nameof(LoginScenePrefabs));
        }

        private void Start()
        {
        }
    }
}