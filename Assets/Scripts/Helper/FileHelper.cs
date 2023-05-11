using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace wwild.helper
{
    using Cysharp.Threading.Tasks;

    public static class FileHelper
    {
        public static void SaveFile<T>(string path, T data) where T : class
        {
            if (File.Exists(path) == false)
                File.Create(path).Close();

            var contents = JsonUtility.ToJson(data);
            File.WriteAllText(path, contents);
        }

        public static async UniTask SaveFileAsync<T>(string path, T data) where T : class
        {
            await UniTask.Yield();

            if (File.Exists(path) == false)
                File.Create(path).Close();

            var contents = JsonUtility.ToJson(data);
            File.WriteAllText(path, contents);
        }

        public static T LoadFile<T>(string path) where T : class, new()
        {
            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
                return new T();
            }

            return JsonUtility.FromJson<T>(path);
        }

        public static async UniTask<T> LoadFileAsync<T>(string path) where T : class, new()
        {
            await UniTask.Yield();

            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
                return new T();
            }

            var contents = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(contents);
        }
    }
}
