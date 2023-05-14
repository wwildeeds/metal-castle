using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.controller
{
    using Cysharp.Threading.Tasks;

    using wwild.player;
    using wwild.common.itf;

    public class PlayerController : MonoBehaviour
    {
        private IFSMSystem m_fsmSystem;
        private IInputSystem m_inputSystem;

        public IFSMSystem FsmSystem => m_fsmSystem;
        public IInputSystem InputSystem => m_inputSystem;

        private void Start()
        {
            InitAsync().Forget();
        }

        private void Update()
        {
        }

        private async UniTask InitAsync()
        {
            m_fsmSystem = GetComponent<PlayerFsmSystem>();
            m_inputSystem = GetComponent<PlayerInputSystem>();

            await UniTask.WaitUntil(() => m_fsmSystem.Initialized && m_inputSystem.Initialized);
        }
    }
}