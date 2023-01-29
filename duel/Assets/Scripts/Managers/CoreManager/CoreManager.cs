using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoreManager 
{
    [SerializeField] [Range(1, 4)] private int _maxPlayers;
    [SerializeField] private bool _botEnabled;

    private StageManager _stageManager;
    private PlayerManager _playerManager;

    public void Init(StageManager stageManager, PlayerManager playerManager) 
    {
        _stageManager = stageManager;
        _playerManager = playerManager;
        _playerManager.Init();
    }
    
    public void StartBattle() 
    {
        _stageManager.CreateStage();
        List<Vector2> playersPosition = 
            _stageManager.CurrentStage.GetPlayersIndex(_playerManager.QuantityPlayerToBattle);
        _playerManager.CreatePlayers(playersPosition); 
    }
    
    public bool OnPlayerJoin(IPlayer player) 
    {
        if (!_playerManager.IsFull(_maxPlayers)) 
        {
            return _playerManager.AddPlayerToBattle(player);
        } 
        
        Debug.LogWarning("[CoreManager][OnPlayerJoin] The maximum amount of players has already been reached" );
        return false;
    }
    
    public void GoToCharacterSelection() 
    {
        UIManager.Show("CharacterSelectionScreen");
    }
}
