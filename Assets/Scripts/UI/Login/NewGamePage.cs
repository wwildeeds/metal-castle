using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace wwild.ui.login
{
    using wwild.common.itf;
    public class NewGamePage : BaseContentPage, IContentPage
    {
        public int InstanceID { get; private set; }

        protected override void Awake()
        {
            Init();
        }

        protected override void Start()
        {
            AddListeners();
        }

        protected override void Init()
        {
            InstanceID = this.GetInstanceID();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
        }

        public void Show()
        {
            canvas.sortingOrder = MAX_ORDER;
        }

        public void Hide()
        {
            canvas.sortingOrder = MIN_ORDER;
        }
    }
}
