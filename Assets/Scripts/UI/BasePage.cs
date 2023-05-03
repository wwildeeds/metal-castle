using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace wwild.ui
{
    using wwild.common.itf;

    public class BasePage : UIBehaviour, IContainer<IContentPage>
    {
        public void RegisterObj(string key, IContentPage obj)
        {
        }

        public void UnRegisterObj(string key)
        {
        }

        public void ClearAll()
        {
        }

        public void Dispose()
        {
        }
    }
}