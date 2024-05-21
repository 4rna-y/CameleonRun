using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Enums;

namespace Chameleon.Player.Component.Interfaces
{
    public interface IPlayerMovement
    {
        public int JumpCount { get; set; }
        public bool IsGrounded { get; set; }
        public float Gravity { get; set; }

        public bool CheckGrounded();
        public void SetRestoredGravity();
        public void SetDecreasedGravity();
        public void Jump();
        public void Move(bool isTitle = false);
        public bool CheckGroundColor(PlayerColorType type);
        public bool CheckFall();
        public void ResetPosition();
    }
}