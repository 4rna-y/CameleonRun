using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Enums;

namespace Chameleon.Player.Component.Interfaces
{
    public interface IPlayerColor
    {
        public float SwapCoolTime { get; }
        public PlayerColorType PlayerColorType { get; }
        public void Swap();
        public void UpdateSwapCoolTime();
        public void ResetColor();
    }
}