using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.manager
{
    using Cysharp.Threading.Tasks;
    using wwild.pattern;
    using wwild.common.model;

    public class GameManager : Singleton<GameManager>
    {
        protected override void Awake()
        {
            destroyable = false;

            base.Awake();
        }

        public void Test()
        { }
    }
}