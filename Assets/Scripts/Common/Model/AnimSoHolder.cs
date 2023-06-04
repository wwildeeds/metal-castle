using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.model.so
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    using wwild.common.flags;
    public class AnimSoHolder : BaseSoHolder, IDisposable
    {
        [SerializeField]
        private string path_animData = "SO/Skill/AnimCommonData";

        private AnimCommonData m_animData;

        public override async UniTask InitAsync()
        {
            soHolder = new Dictionary<short, ScriptableObject>();

            m_animData = await Resources.LoadAsync(path_animData) as AnimCommonData;

            soHolder.Add(((short)AnimSoFlags.CommonAnim), m_animData);
        }

        public T GetAnimSo<T>(AnimSoFlags flag) where T : ScriptableObject
        {
            if (soHolder.ContainsKey(((short)flag)))
                return soHolder[((short)flag)] as T;
            throw new NullReferenceException();
        }

        public void Dispose()
        {
            Resources.UnloadAsset(m_animData);

            m_animData = null;
        }
    }
}
