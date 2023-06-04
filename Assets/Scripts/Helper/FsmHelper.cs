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

            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new AssassinIdleFSM(skillData.GetSkillByFlag(AnimClipFlags.Idle));
            var run = new AssassinRunFSM(skillData.GetSkillByFlag(AnimClipFlags.Run));
            var atkA = new AssassinAttackAFSM(skillData.GetSkillByFlag(AnimClipFlags.AttackA));
            var atkB = new AssassinAttackBFSM(skillData.GetSkillByFlag(AnimClipFlags.AttackB));
            var atkC = new AssassinAttackCFSM(skillData.GetSkillByFlag(AnimClipFlags.AttackC));
            var atkD = new AssassinAttackDFSM(skillData.GetSkillByFlag(AnimClipFlags.AttackD));
            var skillA = new AssassinSkillAFSM(skillData.GetSkillByFlag(AnimClipFlags.SkillA));
            var skillB = new AssassinSkillAFSM(skillData.GetSkillByFlag(AnimClipFlags.SkillB));
            var skillC = new AssassinSkillAFSM(skillData.GetSkillByFlag(AnimClipFlags.SkillC));

            fsmList.Add(idle);
            fsmList.Add(run);
            fsmList.Add(atkA);
            fsmList.Add(atkB);
            fsmList.Add(atkC);
            fsmList.Add(atkD);
            fsmList.Add(skillA);
            fsmList.Add(skillB);
            fsmList.Add(skillC);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateAxeFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimSo<AnimCommonData>(AnimSoFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new AxeIdleFSM(skillData.GetSkillByName(commonData.Idle));
            var run = new AxeRunFSM(skillData.GetSkillByName(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateDualFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimSo<AnimCommonData>(AnimSoFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new DualIdleFSM(skillData.GetSkillByName(commonData.Idle));
            var run = new DualRunFSM(skillData.GetSkillByName(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateKatanaFSM()
        {
            await UniTask.Yield();

            var commonData = SoManager.Instance.GetAnimSo<AnimCommonData>(AnimSoFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;
            var fsmList = new List<IBaseFSM>();
            var idle = new KatanaIdleFSM(skillData.GetSkillByName(commonData.Idle));
            var run = new KatanaRunFSM(skillData.GetSkillByName(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }
    }
}