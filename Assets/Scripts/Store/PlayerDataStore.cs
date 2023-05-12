using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.store
{
    using Cysharp.Threading.Tasks;

    using wwild.scriptableObjects;
    using wwild.common.data;
    using wwild.helper;
    using wwild.common.itf;

    public partial class PlayerDataStore : IDisposable
    {
        private string path_historyData;

        private PlayerData m_playerData;
        private PlayerHistoryData m_historyData;

        public PlayerData PlayerData => m_playerData;
        public PlayerHistoryData HistoryData => m_historyData;

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            path_historyData = string.Format("{0}/{1}", Application.persistentDataPath, "PlayerHistoryModel.json");

            m_historyData = await LoadHistoryDataAsync();
        }

        public async UniTask CreatePlayerDataAsync(PlayerUnitData data)
        {
            m_playerData = new PlayerData(data);

            m_historyData.AddData(m_playerData);

            await OverwriteHistoryDataAsync();
        }

        public async UniTask SetPlayerData(PlayerData data)
        {
            await UniTask.Yield();
            m_playerData?.Dispose();
            m_playerData = data;
        }

        public async UniTask SaveHistoryDataAsync()
        {
            await FileHelper.SaveFileAsync<PlayerHistoryData>(path_historyData, m_historyData);
        }

        public async UniTask<PlayerHistoryData> LoadHistoryDataAsync()
        {
            return await FileHelper.LoadFileAsync<PlayerHistoryData>(path_historyData);
        }

        public async UniTask OverwriteHistoryDataAsync()
        {
            await SaveHistoryDataAsync();

            m_historyData?.Dispose();

            m_historyData = await LoadHistoryDataAsync();
        }

        public async UniTask RemoveHistoryDataAsync(int idx)
        {
            await UniTask.Yield();

            m_historyData.RemoveData(idx);
        }

        public void Dispose()
        {
            m_historyData?.Dispose();
            m_playerData?.Dispose();
        }
    }
}
