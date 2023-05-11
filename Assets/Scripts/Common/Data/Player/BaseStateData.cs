using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace wwild.common.data
{
    using wwild.scriptableObjects;
    [Serializable]
    public class BaseStateData
    {
        [SerializeField]
        private string m_name;
        [SerializeField]
        private int m_id;

        [SerializeField]
        private uint m_minHealth;
        [SerializeField]
        private uint m_maxHealth;

        [SerializeField]
        private uint m_minMana;
        [SerializeField]
        private uint m_maxMana;

        [SerializeField]
        private bool m_isDead;

        [SerializeField]
        private short m_level;
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

        [SerializeField]
        private Vector3 m_position;
        [SerializeField]
        private Vector3 m_eulers;

        public string Name { get { return m_name; } }
        public int ID { get { return m_id; } }
        public uint MinHealth { get { return m_minHealth; } }
        public uint MaxHealth { get { return m_maxHealth; } }
        public uint MinMana { get { return m_minMana; } }
        public uint MaxMana { get { return m_maxMana; } }
        public bool IsDead { get { return m_isDead; } }
        public short Level { get { return m_level; } }
        public short STR { get { return m_str; } }
        public short DEX { get { return m_dex; } }
        public short INT { get { return m_int; } }
        public short MinDamage { get { return m_minDamage; } }
        public short MaxDamage { get { return m_maxDamage; } }
        public short MinDefence { get { return m_minDefence; } }
        public short MaxDefence { get { return m_maxDefence; } }

        public BaseStateData()
        {
        }

        public BaseStateData(UnitData data)
        {
            m_name = data.Name;
            m_minHealth = data.MinHealth;
            m_maxHealth = data.MaxHealth;
            m_minMana = data.MinMana;
            m_maxMana = data.MaxMana;
            m_minDamage = data.MinDamage;
            m_maxDamage = data.MaxDamage;
            m_minDefence = data.MinDefence;
            m_maxDefence = data.MaxDefence;
            m_level = data.Level;
            m_str = data.STR;
            m_dex = data.DEX;
            m_int = data.INT;

            m_id = GetHashCode();

            m_isDead = false;
            m_position = Vector3.zero;
            m_eulers = Vector3.zero;
        }
    }
}
