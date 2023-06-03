using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace wwild.ui
{
    using wwild.common.itf;

    public class BasePage : UIBehaviour, IContainer<short, IContentPage>
    {
        private Dictionary<short, IContentPage> m_containers;

        protected virtual void AddListeners()
        { }

        protected virtual void RemoveListeners()
        { }

        public virtual void Init()
        {
            m_containers = new Dictionary<short, IContentPage>();
        }

        public bool IsRegisteredObj(short key)
        {
            return m_containers.ContainsKey(key);
        }
        
        public void RegisterObj(short key, IContentPage obj)
        {
            if (obj.Equals(null)) throw new System.NullReferenceException();

            m_containers.Add(key, obj);
        }

        public IContentPage GetRegisteredObj(short key)
        {
            if (IsRegisteredObj(key))
                return m_containers[key];
            return null;
        }

        public void UnRegisterObj(short key)
        {
            if (m_containers.ContainsKey(key))
                m_containers.Remove(key);
        }
        public void ClearAll()
        {
        }

    }
}