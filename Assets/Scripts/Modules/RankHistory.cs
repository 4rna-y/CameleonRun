using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankHistory : IComparable<RankHistory>
{
    public GameModes Mode { get; private set; }
    public int Score { get; private set; }

    public RankHistory(GameModes mode, int score)
    {
        Mode = mode;
        Score = score;
    }

    public int CompareTo(RankHistory other)
    {
        return Score.CompareTo(other.Score);
    }
}
