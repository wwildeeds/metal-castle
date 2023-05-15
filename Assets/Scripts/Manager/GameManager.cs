using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.manager
{
    using Cysharp.Threading.Tasks;
    using wwild.pattern;
    using wwild.pool;
    using wwild.common.model;

    public class GameManager : Singleton<GameManager>
    {
        public bool Initialized => initialized;
        public PlayerPool PlayerPool { get; private set; }
        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            PlayerPool = new PlayerPool();

            initialized = true;
        }
    }
}