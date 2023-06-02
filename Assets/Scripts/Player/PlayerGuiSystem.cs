using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;

    public class PlayerGuiSystem : BaseSystem, IGuiSystem
    {
        public bool Initialized { get; private set; }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();
        }

        public void LateUpdateSystem()
        {
        }

        public void UpdateSystem()
        {
        }

        public void Dispose()
        {
        }

        
    }
}
