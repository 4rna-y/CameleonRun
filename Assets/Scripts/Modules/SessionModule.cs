using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionModule
{
    private GameSession _currentSession;
    public void CreateSession(GameModes mode, float time, int death, int point)
    {
        _currentSession = new GameSession(mode, time, death, point);
    }

    public GameModes GetCurrentSessionGameMode()
    {
        return _currentSession.GameMode;
    }

    public float GetCurrentSessionTime()
    {
        return _currentSession.Time;
    }

    public int GetCurrentSessionDeath() 
    {
        return _currentSession.Death;
    }

    public int GetCurrentSessionPoint()
    {
        return _currentSession.Point;
    }
}
