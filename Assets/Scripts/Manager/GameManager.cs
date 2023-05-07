using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.manager
{
    using wwild.pattern;
    using wwild.scriptableObjects;

    public class GameManager : Singleton<GameManager>
    {
        private InGameScenePrefabs m_ingameScenePref;

        public InGameScenePrefabs InGameScenePref { get { return m_ingameScenePref; } }

        protected override void Awake()
        {
            m_ingameScenePref = Resources.Load<InGameScenePrefabs>(nameof(InGameScenePrefabs));
        }
    }
}