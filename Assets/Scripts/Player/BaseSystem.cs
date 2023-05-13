using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;

    public abstract class BaseSystem
    {
        public virtual async UniTask InitAsync() { }
        protected abstract void UpdateSystem();
    }
}
