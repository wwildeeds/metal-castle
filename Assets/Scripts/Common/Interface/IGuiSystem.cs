using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    using wwild.ui.ingame;

    public interface IGuiSystem : IBaseSystem
    {
        public IInfoPage InfoPage { get; }
        public ISkillPage SkillPage { get; }
        public IInventoryPage InventoryPage { get; }
        public IActbarPage ActbarPage { get; }
    }
}