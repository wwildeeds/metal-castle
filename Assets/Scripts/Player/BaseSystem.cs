using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    public abstract class BaseSystem
    {
        protected IPlayerController IPlayerCtrl { get; set; }
    }
}
