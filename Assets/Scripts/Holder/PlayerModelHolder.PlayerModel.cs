using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace wwild.holder
{
    using Cysharp.Threading.Tasks;
    using wwild.common.model.player;
    using wwild.scriptableObjects;
    public partial class PlayerModelHolder
    {
        private PlayerModel m_playerModel;

        public async UniTask SetPlayerAsync(PlayerModel model)
        {
            await UniTask.Yield();

            m_playerModel?.Dispose();

            m_playerModel = model;
        }

        public async UniTask CreatePlayerAsync(PlayerUnitData data)
        {
            m_playerModel = new PlayerModel();
            m_playerModel.Create(data);

            m_historyModel.AddPlayerModel(m_playerModel);

            await SaveHistoryModelAsync();
        }
    }
}
