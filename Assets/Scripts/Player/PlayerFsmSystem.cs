using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.fsm;
    using wwild.common.flags;
    using wwild.common.itf;
    using wwild.scriptableObjects;
    using wwild.manager;
    public class PlayerFsmSystem : BaseSystem, IPlayerFsmSystem
    {
        private Dictionary<string, IBaseFSM> m_fsmDic;

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_fsmDic = new Dictionary<string, IBaseFSM>();

            await CreateFSM();
        }

        private async UniTask CreateFSM()
        {
            var charFlag = DataManager.Instance.PlayerStore.PlayerData.StateData.CharacterFlag;

            switch(charFlag)
            {
                case CharacterFlags.Assassin:
                    await CreateAssassinFSM();
                    break;

                case CharacterFlags.Axe:
                    await CreateAxeFSM();
                    break;

                case CharacterFlags.Dual:
                    await CreateDualFSM();
                    break;

                case CharacterFlags.Katana:
                    await CreateKatanaFSM();
                    break;
            }
        }

        private async UniTask CreateAssassinFSM()
        {
            var animData = SoManager.Instance.GetAnimData<AnimCommonData>(AnimFlags.CommonAnim);
            var skillData = DataManager.Instance.PlayerStore.PlayerData.SkillData;

            var idle = new AssassinIdelFSM(skillData.GetSkill(animData.Idle));



        }

        private async UniTask CreateAxeFSM()
        { }

        private async UniTask CreateDualFSM()
        { }

        private async UniTask CreateKatanaFSM()
        { }

        protected override void UpdateSystem()
        {
        }
    }
}