using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    public interface IContentPage : IDisposable
    {
        int InstanceID { get; }
        bool IsActiveInHierarchy { get; }
        void Show();
        void Hide();
    }
}
