using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon.Player.Component.Interfaces
{
    public interface IPlayerCameraMotion
    {
        public bool IsPlayingDeathMotion { get; }
        public void InMotion();
        public void DeathMotion();
        public void ResetEffect();
        public void GoalMotion();
    }
}