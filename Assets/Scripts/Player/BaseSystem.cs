using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;

    public abstract class BaseSystem : MonoBehaviour
    {
        public virtual async UniTask InitAsync() { await UniTask.Yield(); }
    }
}
