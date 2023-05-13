using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.fsm
{
    using wwild.scriptableObjects;

    public class AssassinIdelFSM : BaseFSM
    {
        public AssassinIdelFSM(SkillData data) : base(data)
        { }

        public override void OnEnter()
        {
            EventPlayAnimation?.Invoke(AnimName);
        }
    }
}
