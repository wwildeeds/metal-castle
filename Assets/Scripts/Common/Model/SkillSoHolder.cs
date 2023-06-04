using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.model.so
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    using wwild.common.flags;
    public class SkillSoHolder : BaseSoHolder, IDisposable
    {
        private string path_assassinSkill = "SO/Skill/Assassin/AssassinSkillSO";
        private string path_axeSkill = "SO/Skill/Axe/AxeSkillSO";
        private string path_dualSkill = "SO/Skill/Dual/DualSkillSO";
        private string path_katanaSkill = "SO/Skill/Katana/KatanaSkillSO";

        public SkillSoHolder()
        {
            soHolder = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            var assassinSO = await Resources.LoadAsync(path_assassinSkill) as ScriptableObject;
            var axeSO = await Resources.LoadAsync(path_axeSkill) as ScriptableObject;
            var dualSO = await Resources.LoadAsync(path_dualSkill) as ScriptableObject;
            var katanaSO = await Resources.LoadAsync(path_katanaSkill) as ScriptableObject;

            soHolder.Add(((short)SkillSoFlags.AssassinSkillModel), assassinSO);
            soHolder.Add(((short)SkillSoFlags.AxeSkillModel), axeSO);
            soHolder.Add(((short)SkillSoFlags.DualSkillModel), dualSO);
            soHolder.Add(((short)SkillSoFlags.KatanaSkillModel), katanaSO);
        }

        public T GetSkillSo<T>(SkillSoFlags flag) where T : ScriptableObject
        {
            if (soHolder.ContainsKey(((short)flag)))
                return soHolder[((short)flag)] as T;
            throw new Exception();
        }

        public void Dispose()
        {
            foreach (var item in soHolder)
            {
                Resources.UnloadAsset(item.Value);
            }

            soHolder.Clear();
            soHolder = null;
        }

    }
}
