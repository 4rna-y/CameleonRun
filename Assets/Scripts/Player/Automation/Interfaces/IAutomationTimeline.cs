using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon.Player.Automation.Interfaces
{
    public interface IAutomationTimeline
    {
        public void Append(IMovementAction action);
        public IMovementAction GetMovementAction(float sec);
        public bool IsFinishedAll();
    }
}