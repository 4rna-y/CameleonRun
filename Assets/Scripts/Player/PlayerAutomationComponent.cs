using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Interfaces;
using Chameleon.Player.Automation.Interfaces;

namespace Chameleon.Player.Component
{
    public class PlayerAutomationComponent : MonoBehaviour, IPlayerAutomation
    { 

        private float _time;

        public void AutomationControl(
            IAutomationTimeline timeline, 
            IPlayerMovement movement, 
            IPlayerColor color,
            IPlayerAnimation animation)
        {
            _time += Time.deltaTime;
            if (timeline.GetMovementAction(_time) is IMovementAction action)
            {
                if (action is JumpMovementAction)
                {
                    movement.Jump();
                    animation.AnimateJumping();
                }
                else
                if (action is SwapMovementAction)
                {
                    animation.AnimateSwapping();
                    color.Swap();
                }
            }
            if (timeline.IsFinishedAll()) _time = 0;
        }
    }
}