using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    public interface IBucket<T> where T : IContentPage
    {
        bool IsBucketEmpty { get; }
        void PushObj(T obj);
        T PeekObj();
        T PopObj();
    }
}
