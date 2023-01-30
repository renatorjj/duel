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
    
    public void CreatePlayers(List<ITile> playersTile)
    {
        for (int i = 0; i < playersTile.Count; i++)
        {
            if (i < _players.Count)
            {
                _players[i].Init(playersTile[i]);
            }
            else
            {
                IPlayer player = Instantiate(_basePlayerPrefab, playersTile[i].Index, Quaternion.identity);
                _players.Add(player);
            }
        }
    }

    public bool AddPlayerToBattle(IPlayer player)
    {
        _activePlayer.Add(player);
        return true;
    }
}
