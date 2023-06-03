using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.fsm
{
    using wwild.common.data;
    using wwild.common.flags;

    public class AssassinSkillCFSM : BaseFSM
    {
        public AssassinSkillCFSM(BaseSkillData data) : base(data)
        { }

        public override void OnEnter()
        {
            IFsmSystem.PlayFSM(AnimFlag);
        }

        public override void OnUpdate()
        {
            EventTimer += Time.deltaTime;

            if (EventTimer >= AnimExitTime)
            {
                IFsmSystem.ChangeFSM(AnimClipFlags.Idle);
                return;
            }

            if (EventTimer >= AnimTranslationTime)
            {
                if (IFsmSystem.HasNextFSM())
                {
                    IFsmSystem.ChangeNextFSM();
                    return;
                }
            }
        }
    }
}
