using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    public interface IContainer<T> where T : IContentPage
    {
        void RegisterObj(string key, T obj);
        void UnRegisterObj(string key);
        bool IsRegisteredObj(string key);
        void ClearAll();
    }

    public interface IContainer<K, T> where K : struct where T : IContentPage
    {
        void RegisterObj(K key, T obj);
        void UnRegisterObj(K key);
        bool IsRegisteredObj(K key);
        void ClearAll();
    }
}