using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model
{
    using wwild.common.flags;

    [Serializable]
    public class SceneModel : IDisposable
    {
        [SerializeField]
        private SceneFlags m_curSceneFlag;
        [SerializeField]
        private SceneFlags m_preSceneFlag;

        public SceneFlags PreSceneFlag => m_preSceneFlag;

        public SceneModel()
        {
            m_curSceneFlag = m_preSceneFlag = SceneFlags.LoginScene;
        }

        public void SetSceneFlag(int idx)
        {
            SetSceneFlag((SceneFlags)idx);
        }
        public void SetSceneFlag(SceneFlags flag)
        {
            m_curSceneFlag = m_preSceneFlag = flag;
        }

        public void Dispose()
        {
        }
    }
}
