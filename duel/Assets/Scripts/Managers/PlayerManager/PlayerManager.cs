using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private BasePlayer _basePlayerPrefab;
    private List<IPlayer> _players;
    private List<IPlayer> _activePlayer;

    public bool IsFull(int maxPlayers) => _players.Count <= maxPlayers;

    public int QuantityPlayerToBattle => _activePlayer.Count;

    public void Init()
    {
        _players = new List<IPlayer>();
        _activePlayer = new List<IPlayer>();
    }
    
    public void CreatePlayers(List<Vector2> playersPosition)
    {
        for (int i = 0; i < playersPosition.Count; i++)
        {
            Vector2 index = playersPosition[i];
            if (i < _players.Count)
            {
                _players[i].Init(index);
            }
            else
            {
                IPlayer player = Instantiate(_basePlayerPrefab, index, Quaternion.identity);
                
            }
        }
    }

    public bool AddPlayerToBattle(IPlayer player)
    {
        _activePlayer.Add(player);
        return true;
    }
}
