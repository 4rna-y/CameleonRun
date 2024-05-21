using Chameleon.Player.Automation.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon.Player.Component.Interfaces
{
    public interface IPlayerAutomation
    { 
        public void AutomationControl(
            IAutomationTimeline timeline, 
            IPlayerMovement movement, 
            IPlayerColor color,
            IPlayerAnimation animation);
    }
}