using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.pool
{
    using Cysharp.Threading.Tasks;

    using wwild.manager;
    public class PlayerPool
    {
        public GameObject MyPlayer { get; private set; }
        public GameObject MyCamera { get; private set; }

        public bool HasPlayer => MyPlayer != null;
        public bool HasCamera => MyCamera != null;

        public void CreatePlayer()
        {
            var path = string.Format("Character/{0}", DataManager.Instance.PlayerStore.PlayerData.StateData.CharacterFlag.ToString());
            var obj = Resources.Load<GameObject>(path);
            var go = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);

            MyPlayer = go;
        }

        public void CreateCamera()
        {
            var path = "Camera/CamController";
            var obj = Resources.Load<GameObject>(path);
            var go = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);

            MyCamera = go;
        }

        public async UniTask CreatePlayerAsync()
        {
            var path = string.Format("Character/{0}", DataManager.Instance.PlayerStore.PlayerData.StateData.CharacterFlag.ToString());
            var obj = await Resources.LoadAsync(path) as GameObject;
            var go = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);

            MyPlayer = go;
        }

        public async UniTask CreateCameraAsync()
        {
            var path = "Camera/CamController";
            var obj = await Resources.LoadAsync(path) as GameObject;
            var go = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);

            MyCamera = go;
        }

        public void SetPlayer(GameObject obj)
        {
            MyPlayer = obj;
        }

        public void SetCamera(GameObject obj)
        {
            MyCamera = obj;
        }
    }
}
