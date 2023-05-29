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

        private void OnInputKeyboard()
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

        private void OnInputMouse()
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
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

            if(Input.GetKeyDown(KeyCode.Mouse1))
            { }
        }

        public void UpdateSystem()
        {
            if (Initialized == false) return;
        }

        public void LateUpdateSystem()
        {
            if (Initialized == false) return;

            OnInputKeyboard();
            OnInputMouse();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        
    }
}