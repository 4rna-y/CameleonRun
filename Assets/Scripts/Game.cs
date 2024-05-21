using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public SessionModule SessionModule { get; private set; }

    public RankModule RankModule { get; private set; }

    private void Awake()
    {
        SessionModule = new SessionModule();
        RankModule = new RankModule();

        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
