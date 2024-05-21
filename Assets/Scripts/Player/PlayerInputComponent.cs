using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Interfaces;

namespace Chameleon.Player.Component
{
    public class PlayerInputComponent : MonoBehaviour, IPlayerInput
    {
        public float JumpInputDownTime { get; set; }

        public bool EnsureJumpInput()
        {
            bool isDown = Input.GetKeyDown(KeyCode.Space);

            if (Input.GetKey(KeyCode.Space)) JumpInputDownTime += Time.deltaTime;
            else JumpInputDownTime = 0;

            return isDown;
        }

        public bool EnsureSwapInput() => Input.GetKeyDown(KeyCode.LeftShift);

        public bool IsDownReset() => Input.GetKeyDown(KeyCode.F11);
    }
}