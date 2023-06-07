using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.ui.ingame
{
    using wwild.common.itf;

    public interface IActbarPage
    { }

    public class PlayerActbarPage : BaseContentPage, IContentPage, IActbarPage
    {
        public int InstanceID { get; private set; }

        public bool IsActiveInHierarchy => this.gameObject.activeInHierarchy;

        protected override void Init()
        {
        }

        public void Hide()
        {
        }

        public void Show()
        {
        }

        protected override void AddListeners()
        {
        }

        protected override void RemoveListeners()
        {
        }

        public void Dispose()
        {
        }

        public T GetContentInterface<T>() where T : class
        {
            var finded = this.TryGetComponent<T>(out var cmp);

            return finded ? cmp : null;
        }
    }
}