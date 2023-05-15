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
        public PlayerController PlayerCtrl { get; private set; }
        public bool Initialized { get; private set; }

        void Start()
        {
            InitAsync().Forget();
        }

        void LateUpdate()
        {
            OnInputKeyboard();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            PlayerCtrl = GetComponent<PlayerController>();
        }

        private void OnInputKeyboard()
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlayerCtrl.MoveSystem.SetMoveDirection(Vector3.forward);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                PlayerCtrl.MoveSystem.SetMoveDirection(Vector3.back);
            }

            if (Input.GetKey(KeyCode.A))
            {
                PlayerCtrl.MoveSystem.SetMoveDirection(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                PlayerCtrl.MoveSystem.SetMoveDirection(Vector3.right);
            }
        }

        public void UpdateSystem()
        {
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}