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

            var idle = new AssassinIdleFSM(skillData.GetDefaultSkillByFlag(AnimClipFlags.Idle));
            var run = new AssassinRunFSM(skillData.GetDefaultSkillByFlag(AnimClipFlags.Run));
            var atkA = new AssassinAttackAFSM(skillData.GetDefaultSkillByFlag(AnimClipFlags.AttackA));
            var atkB = new AssassinAttackBFSM(skillData.GetDefaultSkillByFlag(AnimClipFlags.AttackB));
            var atkC = new AssassinAttackCFSM(skillData.GetDefaultSkillByFlag(AnimClipFlags.AttackC));
            var atkD = new AssassinAttackDFSM(skillData.GetDefaultSkillByFlag(AnimClipFlags.AttackD));

            var skillA = new AssassinSkillAFSM(skillData.GetUniqueSkillByFlag(AnimClipFlags.SkillA));
            var skillB = new AssassinSkillAFSM(skillData.GetUniqueSkillByFlag(AnimClipFlags.SkillB));
            var skillC = new AssassinSkillAFSM(skillData.GetUniqueSkillByFlag(AnimClipFlags.SkillC));

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