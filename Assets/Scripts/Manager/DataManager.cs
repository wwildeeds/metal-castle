using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace wwild.manager
{
    using wwild.pattern;
    using wwild.holder;
    using Cysharp.Threading.Tasks;

    public class DataManager : Singleton<DataManager>
    {
        private PlayerModelHolder m_playerHolder;

        public PlayerModelHolder PlayerHolder => m_playerHolder;

        public bool Initialized => initialized;
        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_playerHolder = new PlayerModelHolder();

            await m_playerHolder.InitAsync();

            initialized = true;
        }
    }
}