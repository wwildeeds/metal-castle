using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.flags
{
    public enum UnitStateFlags : short
    {
        Normal,
        Dead,
        Attack,
        Skill,
        Block,
        Knockdown,
        Airborne,
        Defenseless
    }
}
