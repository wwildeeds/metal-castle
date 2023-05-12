using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.holder
{
    using Cysharp.Threading.Tasks;
    using wwild.common.model.player;
    using wwild.scriptableObjects;
    using wwild.helper;

    public partial class PlayerModelHolder : IDisposable
    {
        private string path_historyModel;

        private PlayerHistoryModel m_historyModel;

        public PlayerHistoryModel HistoryModel => m_historyModel;

        public async UniTask InitAsync()
        {
            await UniTask.Yield();

            path_historyModel = string.Format("{0}/{1}", Application.persistentDataPath, "PlayerHistoryModel.json");

            m_historyModel = await LoadHistoryModelAsync();
        }

        public async UniTask SaveHistoryModelAsync()
        {
            await FileHelper.SaveFileAsync<PlayerHistoryModel>(path_historyModel, m_historyModel);
        }

        public async UniTask<PlayerHistoryModel> LoadHistoryModelAsync()
        {
            return await FileHelper.LoadFileAsync<PlayerHistoryModel>(path_historyModel);
        }

        public async UniTask OverwriteHistoryModelAsync()
        {
            await SaveHistoryModelAsync();

            m_historyModel?.Dispose();

            m_historyModel = await LoadHistoryModelAsync();
        }

        public async UniTask RemoveHistoryModelAsync(int idx)
        {
            await UniTask.Yield();

            HistoryModel.RemovePlayerModel(idx);
        }

        public void Dispose()
        {
            m_historyModel?.Dispose();
            m_playerModel?.Dispose();
        }
    }
}
