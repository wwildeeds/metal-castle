using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.model
{
    using Cysharp.Threading.Tasks;
    public abstract class BaseSoHolder
    {
        protected Dictionary<short, ScriptableObject> soHolder;
        public virtual async UniTask InitAsync() 
        {
            await UniTask.Yield();
        }
    }
}
