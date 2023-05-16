using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.controller
{
    using Cysharp.Threading.Tasks;

    using wwild.player;
    using wwild.common.itf;

    [RequireComponent(typeof(PlayerFsmSystem))]
    [RequireComponent(typeof(PlayerInputSystem))]
    [RequireComponent(typeof(PlayerMoveSystem))]
    public class PlayerController : MonoBehaviour
    {
        private IFSMSystem m_fsmSystem;
        private IInputSystem m_inputSystem;
        private IMoveSystem m_moveSystem;

        public IFSMSystem FsmSystem => m_fsmSystem;
        public IInputSystem InputSystem => m_inputSystem;
        public IMoveSystem MoveSystem => m_moveSystem;

        private void Start()
        {
            InitAsync().Forget();
        }

        private void Update()
        {
            InputSystem.UpdateSystem();
            FsmSystem.UpdateSystem();
            MoveSystem.UpdateSystem();
        }

        private void LateUpdate()
        {
            InputSystem.LateUpdateSystem();
            FsmSystem.LateUpdateSystem();
            MoveSystem.LateUpdateSystem();
        }

        private async UniTask InitAsync()
        {
            m_fsmSystem = GetComponent<PlayerFsmSystem>();
            m_inputSystem = GetComponent<PlayerInputSystem>();
            m_moveSystem = GetComponent<PlayerMoveSystem>();

            await UniTask.WaitUntil(() => m_fsmSystem.Initialized && m_inputSystem.Initialized && m_moveSystem.Initialized);
        }
    }
}