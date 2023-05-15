using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.model.so
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    using wwild.common.flags;
    public class SkillModel : BaseModel, IDisposable
    {
        private string path_assassinSkill = "SO/Skill/Assassin/AssassinSkillSO";
        private string path_axeSkill = "SO/Skill/Axe/AxeSkillSO";
        private string path_dualSkill = "SO/Skill/Dual/DualSkillSO";
        private string path_katanaSkill = "SO/Skill/Katana/KatanaSkillSO";

        public SkillModel()
        {
            modelStore = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            var assassinSO = await Resources.LoadAsync(path_assassinSkill) as ScriptableObject;
            var axeSO = await Resources.LoadAsync(path_axeSkill) as ScriptableObject;
            var dualSO = await Resources.LoadAsync(path_dualSkill) as ScriptableObject;
            var katanaSO = await Resources.LoadAsync(path_katanaSkill) as ScriptableObject;

            modelStore.Add(((short)SkillModelFlags.AssassinSkillModel), assassinSO);
            modelStore.Add(((short)SkillModelFlags.AxeSkillModel), axeSO);
            modelStore.Add(((short)SkillModelFlags.DualSkillModel), dualSO);
            modelStore.Add(((short)SkillModelFlags.KatanaSkillModel), katanaSO);
        }

        public T GetModel<T>(SkillModelFlags flag) where T : ScriptableObject
        {
            if (modelStore.ContainsKey(((short)flag)))
                return modelStore[((short)flag)] as T;
            throw new Exception();
        }

        public void Dispose()
        {
            foreach (var item in modelStore)
            {
                Resources.UnloadAsset(item.Value);
            }

            modelStore.Clear();
            modelStore = null;
        }

    }
}
