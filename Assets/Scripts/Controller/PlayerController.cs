using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.controller
{
    using Cysharp.Threading.Tasks;

    using wwild.player;
    using wwild.common.itf;

    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public bool Initialized { get; private set; }
        public Transform trans { get; private set; }
        public Animator animator { get; private set; }

        public IFSMSystem FsmSystem { get; private set; }

        public IInputSystem InputSystem { get; private set; }

        public IMoveSystem MoveSystem { get; private set; }

        public IStateSystem StateSystem { get; private set; }

        public IGuiSystem GuiSystem { get; private set; }

        private void Start()
        {
            InitAsync().Forget();
        }

        private async UniTask InitAsync()
        {
            trans = this.transform;

            animator = GetComponent<Animator>();
            animator.applyRootMotion = false;

            FsmSystem = new PlayerFsmSystem(this);
            InputSystem = new PlayerInputSystem(this);
            MoveSystem = new PlayerMoveSystem(this);
            StateSystem = new PlayerStateSystem(this);
            GuiSystem = new PlayerGuiSystem(this);

            await FsmSystem.InitAsync();
            await InputSystem.InitAsync();
            await MoveSystem.InitAsync();
            await StateSystem.InitAsync();
            await GuiSystem.InitAsync();

            Initialized = true;
        }

        private void Update()
        {
            if (Initialized == false) return;

            InputSystem.UpdateSystem();
            MoveSystem.UpdateSystem();
            FsmSystem.UpdateSystem();
            StateSystem.UpdateSystem();
        }

        private void LateUpdate()
        {
            if (Initialized == false) return;

            InputSystem.LateUpdateSystem();
            MoveSystem.LateUpdateSystem();
            FsmSystem.LateUpdateSystem();
            StateSystem.LateUpdateSystem();
        }

        
    }
}