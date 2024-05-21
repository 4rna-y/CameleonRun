using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Automation.Interfaces;

public class AutomationTimeline : IAutomationTimeline
{
    private IList<IMovementAction> _movements;
    private IList<bool> _isFinisheds;

    public AutomationTimeline()
    {
        _movements = new List<IMovementAction>();
        _isFinisheds = new List<bool>();
    }

    public void Append(IMovementAction action)
    {
        _movements.Add(action);
        _isFinisheds.Add(false);
    }

    public IMovementAction GetMovementAction(float sec)
    {
        for (int i = 0; i < _movements.Count; i++)
        {
            if (_movements[i].Timing <= sec && !_isFinisheds[i])
            {
                Debug.Log(sec);

                _isFinisheds[i] = true;
                return _movements[i];
            } 
        }
        return null;
    }

    public bool IsFinishedAll()
    {
        foreach (bool f in _isFinisheds)
        {
            if (!f) return false; 
        }
        return true;
    }
}
