using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.helper
{
    using Cysharp.Threading.Tasks;
    using wwild.common.model;
    using wwild.common.data;
    using wwild.common.flags;
    using wwild.common.itf;
    using wwild.common.fsm;
    using wwild.manager;
    using wwild.scriptableObjects;
    public static class FsmHelper
    {
        public static async UniTask<List<IBaseFSM>> CreatePlayerFSMAsync()
        {
            var stateData = DataManager.Instance.PlayerStore.PlayerData.StateData;
            switch(stateData.CharacterFlag)
            {
                case CharacterFlags.Assassin:
                    return await CreateAssassinFSM();
                case CharacterFlags.Axe:
                    return await CreateAxeFSM();
                case CharacterFlags.Dual:
                    return await CreateDualFSM();
                case CharacterFlags.Katana:
                    return await CreateKatanaFSM();
            }
            throw new System.Exception();
        }
        private static async UniTask<List<IBaseFSM>> CreateAssassinFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimModel<AnimCommonData>(AnimScriptableObjFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new AssassinIdleFSM(skillData.GetSkill(AnimClipFlags.Idle));
            var run = new AssassinRunFSM(skillData.GetSkill(AnimClipFlags.Run));
            var atkA = new AssassinAttackAFSM(skillData.GetSkill(AnimClipFlags.AttackA));
            //var atkB = new AssassinAttackAFSM(skillData.GetSkill(AnimClipFlags.AttackB));
            //var atkC = new AssassinAttackAFSM(skillData.GetSkill(AnimClipFlags.AttackC));
            //var atkD = new AssassinAttackAFSM(skillData.GetSkill(AnimClipFlags.AttackD));

            fsmList.Add(idle);
            fsmList.Add(run);
            fsmList.Add(atkA);
            //fsmList.Add(atkB);
            //fsmList.Add(atkC);
            //fsmList.Add(atkD);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateAxeFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimModel<AnimCommonData>(AnimScriptableObjFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new AxeIdleFSM(skillData.GetSkill(commonData.Idle));
            var run = new AxeRunFSM(skillData.GetSkill(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateDualFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimModel<AnimCommonData>(AnimScriptableObjFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new DualIdleFSM(skillData.GetSkill(commonData.Idle));
            var run = new DualRunFSM(skillData.GetSkill(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateKatanaFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimModel<AnimCommonData>(AnimScriptableObjFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new KatanaIdleFSM(skillData.GetSkill(commonData.Idle));
            var run = new KatanaRunFSM(skillData.GetSkill(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }
    }
}