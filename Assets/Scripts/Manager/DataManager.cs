using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace wwild.manager
{
    using wwild.pattern;
    using wwild.common.model.player;
    using wwild.scriptableObjects;
    using wwild.helper;
    using Cysharp.Threading.Tasks;

    public class DataManager : Singleton<DataManager>
    {
        private string path_playerHistoryModel;

        private PlayerHistoryModel m_playerHistoryModel;
        private PlayerModel m_playerModel;

        public bool Initialized => initialized;
        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            path_playerHistoryModel = string.Format("{0}/{1}", Application.persistentDataPath, "PlayerHistoryModel.json");

            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_playerHistoryModel = await FileHelper.LoadFileAsync<PlayerHistoryModel>(path_playerHistoryModel);

            initialized = true;
        }

        public async UniTask CreatePlayerAsync(UnitData data)
        {
            await UniTask.Yield();

            m_playerModel = new PlayerModel();
            m_playerModel.Create(data);

            m_playerHistoryModel.AddPlayerModel(m_playerModel);

            await FileHelper.SaveFileAsync<PlayerHistoryModel>(path_playerHistoryModel, m_playerHistoryModel);
        }

        public PlayerHistoryModel GetPlayerHistory()
        {
            return m_playerHistoryModel;
        }
    }
}