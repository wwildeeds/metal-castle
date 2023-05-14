using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.flags;
    using wwild.helper;
    public class PlayerFsmSystem : BaseSystem, IFSMSystem
    {
        private Dictionary<AnimClipFlags, IBaseFSM> m_fsmDic;
        private Queue<AnimClipFlags> m_fsmQueue;
        private AnimClipFlags m_fsmFlag;

        [SerializeField]
        private Animator m_animator;

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_fsmDic = new Dictionary<AnimClipFlags, IBaseFSM>();
            m_fsmQueue = new Queue<AnimClipFlags>();

            var fsmList = await FsmHelper.CreatePlayerFSMAsync();

            for (int i = 0; i < fsmList.Count; i++)
            {
                var fsm = fsmList[i];
                fsm.RegisterFsmSystem(this);

                RegisterFSM(fsm.AnimFlag, fsm);
            }
        }

        private void RegisterFSM(AnimClipFlags key, IBaseFSM fsm)
        {
            if (m_fsmDic.ContainsKey(key)) throw new System.Exception();

            m_fsmDic.Add(key, fsm);
        }

        protected override void UpdateSystem()
        {
            m_fsmDic[m_fsmFlag]?.OnUpdate();
        }

        public void InputFSM(AnimClipFlags flag)
        {
            m_fsmQueue.Enqueue(flag);
        }

        public void PlayFSM(AnimClipFlags flag)
        {
            m_animator.Play(flag.ToString());
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

        
    }
}