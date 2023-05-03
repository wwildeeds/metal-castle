using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace wwild.ui
{
    using wwild.common.itf;

    public class BasePage : UIBehaviour, IContainer<IContentPage>
    {
        //protected static readonly int MIN_ORDER = 0;
        //protected static readonly int MAX_ORDER = 3000;

        protected Dictionary<string, IContentPage> m_containers;

        public virtual void Init()
        { }

        protected virtual void AddListeners()
        { }

        protected virtual void RemoveListeners()
        { }

        public virtual void RegisterObj(string key, IContentPage obj)
        {
        }

        public virtual void UnRegisterObj(string key)
        {
        }

        public virtual bool IsRegisteredObj(string key)
        {
            return false;
        }

        public virtual void ClearAll()
        {
        }

    }
}