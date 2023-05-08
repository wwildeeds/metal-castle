using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.scriptableObjects.data
{
    [CreateAssetMenu(fileName ="UnitDataSO", menuName ="UnitDataSO")]
    public class UnitDataSO : ScriptableObject
    {
        [SerializeField]
        private string m_name;
        [SerializeField]
        private string m_description;

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

        public string Name => m_name;
        public string Description => m_description;
        public uint MinHealth => m_minHealth;
        public uint MaxHealth => m_maxHealth;
        public uint MinMana => m_minMana;
        public uint MaxMana => m_maxMana;
        public short STR => m_str;
        public short DEX => m_dex;
        public short INT => m_int;
        public short MinDamage => m_minDamage;
        public short MaxDamage => m_maxDamage;
        public short MinDefence => m_minDefence;
        public short MaxDefence => m_maxDefence;

    }
}