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
        private Vector3 m_curDirection;
        public bool Initialized { get; private set; }


        public PlayerMoveSystem()
        { }

        public PlayerMoveSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            Initialized = true;
        }

        public void SetMoveDirection(Vector3 dir)
        {
            m_curDirection += dir;
            m_curDirection = m_curDirection.normalized;
        }

        public void SetMoveSensitivity(float x, float z)
        {
            m_curDirection.x = x;
            m_curDirection.z = z;
            m_curDirection = m_curDirection.normalized;
        }

        public void Movement()
        {
            if (m_curDirection == Vector3.zero) return;

            IPlayerCtrl.trans.position += m_curDirection * Time.deltaTime * 2f;
        }

        public void Rotatement()
        {
            if (m_curDirection == Vector3.zero) return;

            var dir = (IPlayerCtrl.trans.position + m_curDirection) - IPlayerCtrl.trans.position;
            var from = IPlayerCtrl.trans.rotation;
            var to = Quaternion.LookRotation(dir);

            IPlayerCtrl.trans.rotation = Quaternion.Slerp(from, to, 0.2f);
        }

        public void UpdateSystem()
        {
            if (Initialized == false) return;

            Rotatement();
            Movement();
        }

        public void LateUpdateSystem()
        {
        }

        public void Dispose()
        {
        }

        
    }
}