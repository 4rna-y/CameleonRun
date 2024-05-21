using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RankModule
{
    private List<RankHistory> _history;
    public RankModule()
    {
        _history = new List<RankHistory>();
    }

    public int Add(RankHistory history)
    {
        _history.Add(history);

        if (history.Mode == GameModes.Easy)
        {
            List<RankHistory> list = GetEasyModeHistories().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == history) return i + 1;
            }
            return list.Count;
        }
        else
        if (history.Mode == GameModes.Normal)
        {
            List<RankHistory> list = GetNormalModeHistories().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == history) return i + 1;
            }
            return list.Count;
        }
        else
        {
            List<RankHistory> list = GetHardModeHistories().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == history) return i + 1;
            }
            return list.Count;
        }

    }


    public IEnumerable<RankHistory> GetHistories(GameModes mode)
    {
        List<RankHistory> buf = new List<RankHistory>(_history)
            .Where(x => x.Mode == mode)
            .OrderByDescending(x => x.Score)
            .ToList();

        List<RankHistory> dest = new List<RankHistory>();

        for (int i = 0; i < buf.Count(); i++)
        {
            dest.Add(buf[i]);
        }

        if (dest.Count != 3)
        {
            for (int i = 0; i < 3 - (dest.Count - 1); i++)
            {
                dest.Add(null);
            }
        }
        Debug.Log(dest.Count);
        return dest;
    }
    public IEnumerable<RankHistory> GetEasyModeHistories()
    {
        IEnumerable<RankHistory> buf = new List<RankHistory>(_history)
            .Where(x => x.Mode == GameModes.Easy)
            .OrderByDescending(x => x.Score);

        return buf;
    }

    public IEnumerable<RankHistory> GetNormalModeHistories()
    {
        IEnumerable<RankHistory> buf = new List<RankHistory>(_history)
            .Where(x => x.Mode == GameModes.Normal)
            .OrderByDescending(x => x.Score);

        return buf;
    }

    public IEnumerable<RankHistory> GetHardModeHistories()
    {
        IEnumerable<RankHistory> buf = new List<RankHistory>(_history)
            .Where(x => x.Mode == GameModes.Hard)
            .OrderByDescending(x => x.Score);

        return buf;
    }
}
