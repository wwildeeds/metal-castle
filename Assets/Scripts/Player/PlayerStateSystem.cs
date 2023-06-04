namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.data;
    using wwild.common.flags;
    using wwild.common.itf;
    using wwild.manager;

    public class PlayerStateSystem : BaseSystem, IStateSystem
    {
        private PlayerData m_playerData;

        public UnitStateFlags CurStateFlag => m_playerData.StateData.StateFlag;

        public bool Initialized { get; private set; }

        public PlayerStateSystem()
        { }

        public PlayerStateSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public async UniTask InitAsync()
        {
            await UniTask.WaitUntil(() => DataManager.Instance.Initialized);
            m_playerData = DataManager.Instance.PlayerStore.PlayerData;

            Initialized = true;
        }

        public bool CompareState(UnitStateFlags flag)
        {
            return CurStateFlag == flag;
        }

        public void UpdateSystem()
        {
            if (CompareFsmState(AnimClipFlags.Idle) || CompareFsmState(AnimClipFlags.Run))
            {
                m_playerData.StateData.ChangePlayerState(UnitStateFlags.Normal);
            }
            else if (CompareFsmState(AnimClipFlags.AttackA) || CompareFsmState(AnimClipFlags.AttackB) ||
                     CompareFsmState(AnimClipFlags.AttackC) || CompareFsmState(AnimClipFlags.AttackD))
            {
                m_playerData.StateData.ChangePlayerState(UnitStateFlags.Attack);
            }
            else if (CompareFsmState(AnimClipFlags.SkillA) || CompareFsmState(AnimClipFlags.SkillB) ||
                     CompareFsmState(AnimClipFlags.SkillC) || CompareFsmState(AnimClipFlags.SkillD))
            {
                m_playerData.StateData.ChangePlayerState(UnitStateFlags.Skill);
            }
        }

        public void LateUpdateSystem()
        {

        }

        private bool CompareFsmState(AnimClipFlags flag)
        {
            return IPlayerCtrl.FsmSystem.CurFsmFlag == flag;
        }

        public void Dispose()
        {
        }

        
    }
}
