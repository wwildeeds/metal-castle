using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    public interface IMoveSystem : IBaseSystem
    {
        void SetMoveDirection(Vector3 dir);
        void SetMoveSensitivity(float x, float z);
        void Movement();
        void Rotatement();
    }
}
