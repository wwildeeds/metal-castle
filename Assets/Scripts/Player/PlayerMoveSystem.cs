using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.flags;
    using wwild.common.itf;
    using wwild.controller;

    public class PlayerMoveSystem : BaseSystem, IMoveSystem
    {
        private CharacterController m_characterCtrl;
        private Vector3 m_curDirection;

        public PlayerController PlayerCtrl { get; private set; }
        public bool Initialized { get; private set; }

        void Start()
        {
            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            PlayerCtrl = GetComponent<PlayerController>();

            Initialized = true;
        }

        void Update()
        {
            if (Initialized == false) return;

            Rotatement();
            Movement();
        }

        public void SetMoveDirection(Vector3 dir)
        {
            m_curDirection += dir;
            m_curDirection = m_curDirection.normalized;

            PlayerCtrl.FsmSystem.PlayFSM(AnimClipFlags.Run);
        }

        public void Movement()
        {
            if (m_curDirection == Vector3.zero)
            {
                PlayerCtrl.FsmSystem.PlayFSM(AnimClipFlags.Idle);
                return;
            }

            
            transform.position += m_curDirection * Time.deltaTime * 2f;

            m_curDirection = Vector3.zero;
        }

        public void Rotatement()
        {
            if (m_curDirection == Vector3.zero)
            {
                return;
            }

            var dir = (transform.position + m_curDirection) - transform.position;
            var from = transform.rotation;
            var to = Quaternion.LookRotation(dir);
            
            transform.rotation = Quaternion.Slerp(from, to, 0.2f);
        }

        public void UpdateSystem()
        {
        }

        public void Dispose()
        {
        }
    }
}