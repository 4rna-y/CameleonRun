using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession
{
    public GameModes GameMode { get; }
    public float Time { get; }
    public int Death { get; }
    public int Point { get; }

    public GameSession(GameModes mode, float time, int death, int points)
    {
        GameMode = mode;
        Time = time;
        Death = death;
        Point = points;
    }
}
