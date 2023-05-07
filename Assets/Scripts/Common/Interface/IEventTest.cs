using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.common.itf
{
    public interface IEventTest
    {
        event Action<string, string> func1;
    }
}
