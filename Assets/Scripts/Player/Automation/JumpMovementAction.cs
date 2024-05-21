using Chameleon.Player.Automation.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovementAction : IMovementAction
{
    public float Timing { get; }
    public JumpMovementAction(float sec)
    {
        Timing = sec;
    }
}
