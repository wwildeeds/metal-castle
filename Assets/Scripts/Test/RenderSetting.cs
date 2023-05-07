using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.setting
{
    public class RenderSetting : MonoBehaviour
    {
        public float speed;
        private float rotate;
        // Update is called once per frame
        void Update()
        {
            rotate += Time.deltaTime * speed;
            RenderSettings.skybox.SetFloat("_Rotation", rotate);
        }
    }
}