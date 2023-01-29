using System;
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
    
    public void GoToCharacterSelection() 
    {
        UIManager.Show("CharacterSelectionScreen");
    }
}
