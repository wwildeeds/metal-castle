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
        private string path_assassinSkill = "SO/Skill/Assassin/AssassinSkillData";
        private string path_axeSkill = "";
        private string path_dualSkill = "";
        private string path_katanaSkill = "";

        public SkillModel()
        {
            modelStore = new Dictionary<short, ScriptableObject>();
        }

        public override async UniTask InitAsync()
        {
            await UniTask.Yield();

            var assassinSO = await Resources.LoadAsync(path_assassinSkill) as ScriptableObject;
            modelStore.Add(((short)SkillModelFlags.AssassinSkillModel), assassinSO);
        }

        public T GetModel<T>(SkillModelFlags flag) where T : ScriptableObject
        {
            if (modelStore.ContainsKey(((short)flag)))
                return modelStore[((short)flag)] as T;
            throw new Exception();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
