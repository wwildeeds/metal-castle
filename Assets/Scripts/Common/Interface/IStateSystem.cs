using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    using wwild.common.flags;
    public interface IStateSystem : IBaseSystem
    {
        UnitStateFlags CurStateFlag { get; }
        bool CompareState(UnitStateFlags flag);
    }
}
