using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    private Vector2 _index;
    private IBaseCollectableItem _baseCollectableItem;
    private IPlayer _player;
    
    public Vector2 Index => _index;
    public bool IsActive => gameObject.activeSelf;
    public IPlayer Player => _player;
    
    public bool CanMove() => Player == null && IsActive;
    
    public void Init(Vector2? index)
    {
        _index = index ?? _index;
        gameObject.SetActive(true);
    }

    public void Clear()
    {
        _player = null;
        gameObject.SetActive(false);
    }
    

    public void SetPlayer(IPlayer player)
    {
        _player = player;
    }
}
