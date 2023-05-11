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
        private string path_historyPlayerModel;

        private HistoryPlayerModel m_historyPlayerModel;
        private PlayerModel m_playerModel;

        public bool Initialized => initialized;
        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            path_historyPlayerModel = string.Format("{0}/{1}", Application.persistentDataPath, "HistoryPlayerModel.json");

            InitAsync().Forget();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            m_historyPlayerModel = await FileHelper.LoadFileAsync<HistoryPlayerModel>(path_historyPlayerModel);

            initialized = true;
        }

        public async UniTask CreatePlayerAsync(UnitData data)
        {
            await UniTask.Yield();

            m_playerModel = new PlayerModel();
            m_playerModel.Create(data);

            m_historyPlayerModel.AddPlayerModel(m_playerModel);

            await FileHelper.SaveFileAsync<HistoryPlayerModel>(path_historyPlayerModel, m_historyPlayerModel);
        }
    }
}