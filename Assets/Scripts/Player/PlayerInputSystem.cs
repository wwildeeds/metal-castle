using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.flags;
    using wwild.controller;
    

    public class PlayerInputSystem : BaseSystem, IInputSystem
    {
        public bool Initialized { get; private set; }


        public PlayerInputSystem()
        { }

        public PlayerInputSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            Initialized = true;
        }

        private void OnInputMovementKey()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");

            if (IPlayerCtrl.StateSystem.CurStateFlag != UnitStateFlags.Normal)
            {
                if (x != 0.0f || z != 0.0f)
                {
                    IPlayerCtrl.FsmSystem.ClearFSM();
                }

                IPlayerCtrl.MoveSystem.SetMoveDirection(Vector3.zero);
                return;
            }

            IPlayerCtrl.MoveSystem.SetMoveSensitivity(x, z);

            if (x == 0.0f && z == 0.0f)
                IPlayerCtrl.FsmSystem.ChangeFSM(AnimClipFlags.Idle);
            else
                IPlayerCtrl.FsmSystem.ChangeFSM(AnimClipFlags.Run);
        }

        private void OnInputAttackKey()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;

                if (IPlayerCtrl.StateSystem.CurStateFlag == UnitStateFlags.Normal)
                {
                    IPlayerCtrl.FsmSystem.ChangeFSM(AnimClipFlags.AttackA);
                }
                else
                {
                    switch (IPlayerCtrl.FsmSystem.CurFsmFlag)
                    {
                        case AnimClipFlags.AttackA:
                            IPlayerCtrl.FsmSystem.InputFSM(AnimClipFlags.AttackB);
                            break;

                        case AnimClipFlags.AttackB:
                            IPlayerCtrl.FsmSystem.InputFSM(AnimClipFlags.AttackC);
                            break;

                        case AnimClipFlags.AttackC:
                            IPlayerCtrl.FsmSystem.InputFSM(AnimClipFlags.AttackD);
                            break;

                        case AnimClipFlags.AttackD:
                            IPlayerCtrl.FsmSystem.InputFSM(AnimClipFlags.AttackA);
                            break;
                        default:
                            IPlayerCtrl.FsmSystem.InputFSM(AnimClipFlags.AttackA);
                            break;
                    }
                }
            }
        }

        private void OnInputSkillKey()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ExecuteInputedSkill(AnimClipFlags.SkillA);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ExecuteInputedSkill(AnimClipFlags.SkillB);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ExecuteInputedSkill(AnimClipFlags.SkillC);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ExecuteInputedSkill(AnimClipFlags.SkillD);
            }
        }

        private void OnInputGuardKey()
        { }

        private void ExecuteInputedSkill(AnimClipFlags flag)
        {
            //캐릭터 상태 이상 (죽음, 스턴, 에어본, 넉백 등) 시 스킬 사용할수 없음

            if (IPlayerCtrl.StateSystem.CompareState(UnitStateFlags.Normal))
            {
                IPlayerCtrl.FsmSystem.ChangeFSM(flag);
            }
            else
            {
                if (IPlayerCtrl.StateSystem.CompareState(UnitStateFlags.Skill) || IPlayerCtrl.StateSystem.CompareState(UnitStateFlags.Attack))
                    IPlayerCtrl.FsmSystem.InputFSM(flag);
            }
        }

        public void UpdateSystem()
        {
            if (Initialized == false) return;

            OnInputMovementKey();
            OnInputAttackKey();
            OnInputGuardKey();
            OnInputSkillKey();
        }

        public void LateUpdateSystem()
        {
            if (Initialized == false) return;
        }

        public void Dispose()
        {
        }
    }
}