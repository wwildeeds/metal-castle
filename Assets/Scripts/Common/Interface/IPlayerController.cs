using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.common.itf
{
    public interface IPlayerController
    {
        Transform trans { get; }
        Animator animator { get; }

        IFSMSystem FsmSystem { get; }
        IInputSystem InputSystem { get; }
        IMoveSystem MoveSystem { get; }
        IStateSystem StateSystem { get; }
        IGuiSystem GuiSystem { get; }

    }
}
