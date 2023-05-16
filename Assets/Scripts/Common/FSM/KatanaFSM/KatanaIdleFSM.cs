using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.fsm
{
    using wwild.common.data;
    public class KatanaIdleFSM : BaseFSM
    {
        public KatanaIdleFSM(BaseSkillData data) : base(data)
        { }

        public override void OnEnter()
        {
            IFsmSystem.PlayFSM(AnimFlag);
        }
    }
}
