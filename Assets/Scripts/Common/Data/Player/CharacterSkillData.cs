using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
namespace wwild.common.data
{
    using Cysharp.Threading.Tasks;
    using wwild.scriptableObjects;
    public class CharacterSkillData : BaseSkillData, IDisposable
    {
        CancellationTokenSource tokenSource;

        public CharacterSkillData(SkillSo skillSo) : base(skillSo)
        {
            tokenSource = new CancellationTokenSource();
        }

        public async UniTask ExecuteSkillAsync()
        {
            await UniTask.Yield();

            m_skillCoolDone = false;
            while (true)
            {
                if (tokenSource.Token.IsCancellationRequested) break;

                m_skillMinCooltime -= Time.deltaTime;

                if(m_skillMinCooltime <= 0.0f)
                {
                    m_skillMinCooltime = m_skillMaxCooltime;
                    m_skillCoolDone = true;
                    break;
                }

                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
        public void Dispose()
        {
            tokenSource.Cancel();
        }
    }
}