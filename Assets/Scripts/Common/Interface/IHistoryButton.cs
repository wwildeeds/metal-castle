using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.itf
{
    public interface IHistoryButton : IDisposable
    {
        void SetData(string name, string id, string characterFlag, string level);
    }
}
