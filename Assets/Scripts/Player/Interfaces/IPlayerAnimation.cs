using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon.Player.Component.Interfaces
{
    public interface IPlayerAnimation
    {
        public void AnimateWalking();
        public void AnimateJumping();
        public void AnimateSwapping();
        public void AnimateLanding();
        public void PauseAll();
        public void PlayAll();
    }
}