using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    private Vector2 _index;
    private IBaseCollectableItem _baseCollectableItem;
    private IPlayer _currentCurrentPlayer;
    
    public Vector2 Index => _index;
    public bool IsActive => gameObject.activeSelf;
    public IPlayer CurrentPlayer => _currentCurrentPlayer;
    public bool CanMove => CurrentPlayer == null && IsActive;
    
    public void Init(Vector2? index)
    {
        _index = index ?? _index;
        gameObject.SetActive(true);
    }

    public void Clear()
    {
        _currentCurrentPlayer = null;
        _baseCollectableItem = null;
        gameObject.SetActive(false);
    }
    
    public void SetCurrentPlayer(IPlayer player)
    {
        _currentCurrentPlayer = player;
    }
}
