using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon.Player.Component.Interfaces
{
    public interface IPlayerInput
    {
        public float JumpInputDownTime { get; }
        public bool EnsureJumpInput();
        public bool EnsureSwapInput();
        public bool IsDownReset();
    }
}