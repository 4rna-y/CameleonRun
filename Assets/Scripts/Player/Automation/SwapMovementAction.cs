using Chameleon.Player.Automation.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMovementAction : IMovementAction
{
    public float Timing { get; }

    public SwapMovementAction(float sec)
    {
        Timing = sec;
    }
}
