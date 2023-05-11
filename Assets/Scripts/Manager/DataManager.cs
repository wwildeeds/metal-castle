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
        private string path_playerModel;
        private PlayerModel m_playerModel;

        protected override void Awake()
        {
            destroyable = false;

            base.Awake();

            path_playerModel = string.Format("{0}/{1}", Application.persistentDataPath, "PlayerModel.txt");
        }

        public override UniTask InitAsync()
        {
            return base.InitAsync();
        }

        public void CreatePlayer(UnitData data)
        {
            m_playerModel = new PlayerModel();
            m_playerModel.Create(data);

            FileHelper.SaveFile<PlayerModel>(path_playerModel, m_playerModel);
        }
    }
}