using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.data
{
    [Serializable]
    public class BaseStateData
    {
        [SerializeField]
        private string m_name;

        [SerializeField]
        private uint m_minHealth;
        [SerializeField]
        private uint m_maxHealth;

        [SerializeField]
        private uint m_minMana;
        [SerializeField]
        private uint m_maxMana;

        [SerializeField]
        private short m_str;
        [SerializeField]
        private short m_dex;
        [SerializeField]
        private short m_int;

        [SerializeField]
        private short m_minDamage;
        [SerializeField]
        private short m_maxDamage;

        [SerializeField]
        private short m_minDefence;
        [SerializeField]
        private short m_maxDefence;

        public BaseStateData()
        {
        }
    }
}
