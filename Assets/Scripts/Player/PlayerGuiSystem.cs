using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.player
{
    using Cysharp.Threading.Tasks;
    using wwild.common.itf;
    using wwild.common.flags;
    using wwild.scriptableObjects;
    using wwild.manager;
    using wwild.ui.ingame;
    using wwild.helper;

    public class PlayerGuiSystem : BaseSystem, IGuiSystem
    {
        public bool Initialized { get; private set; }

        public IInfoPage InfoPage { get; private set; }

        public ISkillPage SkillPage { get; private set; }

        public IInventoryPage InventoryPage { get; private set; }

        public IActbarPage ActbarPage { get; private set; }

        /// <summary>
        /// InGamePage content interface
        /// </summary>
        private InGamePage m_gamePage;

        public PlayerGuiSystem(IPlayerController ipc)
        {
            IPlayerCtrl = ipc;
        }

        public async UniTask InitAsync()
        {
            await UniTask.WaitUntil(() => SoManager.Instance.Initialized);

            await CreateInGamePageAsync();
            await CreateInfoPageAsync();
            await CreateSkillPageAsync();
            await CreateInventoryPageAsync();
            await CreateActbarPageAsync();

            Initialized = true;
        }

        private async UniTask CreateInGamePageAsync()
        {
            var path = SoManager.Instance.GetGuiModel<PlayerGuiData>(GuiFlags.PlayerGui).InGamePage;
            var pref = await Resources.LoadAsync(path) as GameObject;
            var obj = GameObject.Instantiate(pref, Vector3.zero, Quaternion.identity);

            if (obj.TryGetComponent<InGamePage>(out var cmp))
            {
                m_gamePage = cmp;

                if (UnityEngine.EventSystems.EventSystem.current == null)
                {
                    pref = await Resources.LoadAsync("EventSystem") as GameObject;
                    GameObject.Instantiate(pref, Vector3.zero, Quaternion.identity);
                }

                await UniTask.Yield(PlayerLoopTiming.Initialization);
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }

        private async UniTask CreateInfoPageAsync()
        {
            if (InfoPage != null) return;

            var key = ((short)PlayerGuiFlags.PlayerInfo);
            if (m_gamePage.IsRegisteredObj(key))
            {
                InfoPage = m_gamePage.GetRegisteredObj(key).GetContentInterface<IInfoPage>();
            }
            else
            {
                var path = SoManager.Instance.GetGuiModel<PlayerGuiData>(GuiFlags.PlayerGui).PlayerInfoPage;
                var go = await CreatorHelper.CreateGoAsync(path);
                InfoPage = go.GetComponent<IInfoPage>();

                var contentPage = go.GetComponent<IContentPage>();
                contentPage.Hide();

                m_gamePage.RegisterObj(key, contentPage);
            }

        }

        private async UniTask CreateSkillPageAsync()
        {
            if (SkillPage != null) return;

            var key = ((short)PlayerGuiFlags.PlayerSkill);
            if(m_gamePage.IsRegisteredObj(key))
            {
                SkillPage = m_gamePage.GetRegisteredObj(key).GetContentInterface<ISkillPage>();
            }
            else
            {
                var path = SoManager.Instance.GetGuiModel<PlayerGuiData>(GuiFlags.PlayerGui).PlayerSkillPage;
                var go = await CreatorHelper.CreateGoAsync(path);
                SkillPage = go.GetComponent<ISkillPage>();

                var contentPage = go.GetComponent<IContentPage>();
                contentPage.Hide();

                m_gamePage.RegisterObj(key, contentPage);
            }
        }

        private async UniTask CreateInventoryPageAsync()
        {
            if (InventoryPage != null) return;

            var key = ((short)PlayerGuiFlags.PlayerInventory);
            if (m_gamePage.IsRegisteredObj(key))
            {
                InventoryPage = m_gamePage.GetRegisteredObj(key).GetContentInterface<IInventoryPage>();
            }
            else
            {
                var path = SoManager.Instance.GetGuiModel<PlayerGuiData>(GuiFlags.PlayerGui).PlayerInventoryPage;
                var go = await CreatorHelper.CreateGoAsync(path);
                InventoryPage = go.GetComponent<IInventoryPage>();

                var contentPage = go.GetComponent<IContentPage>();
                contentPage.Hide();
                m_gamePage.RegisterObj(key, contentPage);
            }
        }

        private async UniTask CreateActbarPageAsync()
        {
            if (ActbarPage != null) return;

            var key = ((short)PlayerGuiFlags.PlayerActbar);
            if (m_gamePage.IsRegisteredObj(key))
            {
                ActbarPage = m_gamePage.GetRegisteredObj(key).GetContentInterface<IActbarPage>();
            }
            else
            {
                var path = SoManager.Instance.GetGuiModel<PlayerGuiData>(GuiFlags.PlayerGui).PlayerActbarPage;
                var go = await CreatorHelper.CreateGoAsync(path);
                ActbarPage = go.GetComponent<IActbarPage>();

                var contentPage = go.GetComponent<IContentPage>();
                contentPage.Hide();
                m_gamePage.RegisterObj(key, contentPage);
            }
        }

        public void LateUpdateSystem()
        {
        }

        public void UpdateSystem()
        {
        }

        public void Dispose()
        {
        }
    }
}