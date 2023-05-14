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

            var commonData = SoManager.Instance.GetAnimData<AnimCommonData>(AnimScriptableObjFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;

            var fsmList = new List<IBaseFSM>();

            var idle = new AssassinIdleFSM(skillData.GetSkill(commonData.Idle));
            var run = new AssassinRunFSM(skillData.GetSkill(commonData.Run));

            fsmList.Add(idle);
            fsmList.Add(run);

            return fsmList;
        }

        private static async UniTask<List<IBaseFSM>> CreateAxeFSM()
        {
            return null;
        }

        private static async UniTask<List<IBaseFSM>> CreateDualFSM()
        {
            return null;
        }

        private static async UniTask<List<IBaseFSM>> CreateKatanaFSM()
        {
            return null;
        }
    }
}