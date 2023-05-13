using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.model
{
    using Cysharp.Threading.Tasks;
    public abstract class BaseModel
    {
        protected Dictionary<short, ScriptableObject> modelStore;
        public virtual async UniTask InitAsync() 
        {
            await UniTask.Yield();
        }
    }
}
