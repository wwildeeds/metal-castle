using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model.so
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    using wwild.common.flags;
    public class AnimModel : BaseModel, IDisposable
    {
        [SerializeField]
        private string path_animData;

        private AnimCommonData m_animData;

        public override async UniTask InitAsync()
        {
            modelStore = new Dictionary<short, ScriptableObject>();

            m_animData = await Resources.LoadAsync(path_animData) as AnimCommonData;

            modelStore.Add(((short)AnimFlags.CommonAnim), m_animData);
        }

        public T GetAnimData<T>(AnimFlags flag) where T : ScriptableObject
        {
            if (modelStore.ContainsKey(((short)flag)))
                return modelStore[((short)flag)] as T;
            throw new NullReferenceException();
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_animData);

            m_animData = null;
        }
    }
}
