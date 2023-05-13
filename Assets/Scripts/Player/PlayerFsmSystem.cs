using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.data;
    using wwild.common.itf;
    public class PlayerFsmSystem : BaseSystem
    {
        private Dictionary<string, IBaseFSM> m_fsmDic;

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_fsmDic = new Dictionary<string, IBaseFSM>();
        }
        protected override void UpdateSystem()
        {
        }
    }
}