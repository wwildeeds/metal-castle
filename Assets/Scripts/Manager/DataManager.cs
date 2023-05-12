using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace wwild.manager
{
    using wwild.pattern;
    using wwild.common.data;
    using wwild.store;
    using Cysharp.Threading.Tasks;

    public class DataManager : Singleton<DataManager>
    {
        private PlayerDataStore m_playerStore;

        public PlayerDataStore PlayerStore => m_playerStore;

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

            m_playerStore = new PlayerDataStore();

            await m_playerStore.InitAsync();

            initialized = true;
        }
    }
}