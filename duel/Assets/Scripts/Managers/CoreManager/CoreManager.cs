using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoreManager 
{
    [SerializeField]
    private bool _botEnabled;

    private StageManager _stageManager;
    

    public void Init(StageManager stageManager) 
    {
        _stageManager = stageManager;
    }
}
