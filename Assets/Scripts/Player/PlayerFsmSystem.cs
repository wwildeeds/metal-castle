using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.flags;
    using wwild.helper;
    using wwild.controller;

    public class PlayerFsmSystem : BaseSystem, IFSMSystem
    {
        private Dictionary<AnimClipFlags, IBaseFSM> m_fsmDic;
        private Queue<AnimClipFlags> m_fsmQueue;
        private AnimClipFlags m_fsmFlag;

        public bool Initialized { get; private set; }

        public AnimClipFlags CurFsmFlag => m_fsmFlag;

        public PlayerFsmSystem()
        { }

        public PlayerFsmSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_fsmDic = new Dictionary<AnimClipFlags, IBaseFSM>();
            m_fsmQueue = new Queue<AnimClipFlags>();
            m_fsmFlag = AnimClipFlags.Idle;

            var fsmList = await FsmHelper.CreatePlayerFSMAsync();

            for (int i = 0; i < fsmList.Count; i++)
            {
                var fsm = fsmList[i];
                fsm.RegisterFsmSystem(this);

                RegisterFSM(fsm.AnimFlag, fsm);
            }

            Initialized = true;
        }

        private void RegisterFSM(AnimClipFlags key, IBaseFSM fsm)
        {
            if (m_fsmDic.ContainsKey(key)) throw new System.Exception();

            m_fsmDic.Add(key, fsm);
        }

        public void InputFSM(AnimClipFlags flag)
        {
            if (HasNextFSM())
            {
                if (m_fsmQueue.Peek() == flag) return;
                else m_fsmQueue.Dequeue();
            }

            m_fsmQueue.Enqueue(flag);
        }

        public void PlayFSM(AnimClipFlags flag)
        {
            IPlayerCtrl.animator.Play(m_fsmFlag.ToString());
        }

        public void ChangeFSM(AnimClipFlags flag)
        {
            if (m_fsmFlag == flag) return;

            m_fsmDic[m_fsmFlag].OnExit();
            m_fsmFlag = flag;
            m_fsmDic[m_fsmFlag].OnEnter();
        }

        public void ChangeNextFSM()
        {
            var fsm = m_fsmQueue.Dequeue();
            ChangeFSM(fsm);
        }

        public bool HasNextFSM()
        {
            return m_fsmQueue.Count > 0;
        }

        public void ClearFSM()
        {
            if (HasNextFSM())
                m_fsmQueue.Clear();
        }

        public void UpdateSystem()
        {
            if (Initialized == false) return;

            m_fsmDic[m_fsmFlag]?.OnUpdate();
        }

        public void LateUpdateSystem()
        {
        }

        public void Dispose()
        {
        }

        
    }
}