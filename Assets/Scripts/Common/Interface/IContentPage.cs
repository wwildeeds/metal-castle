using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    public interface IContentPage
    {
        int InstanceID { get; }
        void Show();
        void Hide();
    }
}
