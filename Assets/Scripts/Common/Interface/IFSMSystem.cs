using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    using wwild.common.flags;
    public interface IFSMSystem : IBaseSystem
    {
        void InputFSM(AnimClipFlags flag);
        void PlayFSM(AnimClipFlags flag);
        void ChangeFSM(AnimClipFlags flag);
        void ChangeNextFSM();
        bool HasNextFSM();
    }
}