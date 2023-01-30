using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoreManager 
{
    [SerializeField] [Range(2, 4)] private int _maxPlayers;
    [SerializeField] private bool _botEnabled; //This variable says if there will be a bot in the match,
                                               //if there is a vacancy for a player left

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
        List<ITile> playersTile = 
            _stageManager.CurrentStage.GetStartedPlayersIndex(_playerManager.QuantityPlayerToBattle);
        _playerManager.CreatePlayers(playersTile); 
        _stageManager.CurrentStage.InitItems();
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
