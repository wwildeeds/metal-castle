using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.helper
{
    using Cysharp.Threading.Tasks;
    public static class CreatorHelper
    {
        public static async UniTask<GameObject> CreateGoAsync(string srcPath)
        {
            try
            {
                var pref = await Resources.LoadAsync(srcPath) as GameObject;
                var obj = GameObject.Instantiate(pref);
                return obj;
            }
            catch
            {
                throw new System.Exception("not found src path obj");
            }
        }
    }
}
