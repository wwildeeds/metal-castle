using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace wwild.helper
{
    public static class FileHelper
    {
        public static void SaveFile<T>(string path, T data) where T : class
        {
            if (File.Exists(path) == false)
                File.Create(path).Close();

            var contents = JsonUtility.ToJson(data);
            File.WriteAllText(path, contents);
        }
    }
}
