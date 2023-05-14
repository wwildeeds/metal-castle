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
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                PlayerCtrl.FsmSystem.PlayFSM(AnimClipFlags.Run);
            }
            else
            {
                PlayerCtrl.FsmSystem.PlayFSM(AnimClipFlags.Idle);
            }
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            PlayerCtrl = GetComponent<PlayerController>();
        }

        public void UpdateSystem()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}