using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayer
{
    [SerializeField] [Range(50, 100)] protected  int _life;

    protected int _currenteLife;
    protected ITile _currentTile;
    protected  List<IBaseCollectableItem> _currentItems;

    public Vector2 CurrentIndex => _currentTile.Index;
    public bool CanCollectItem => _currenteLife > 0;
    
    public void Init(ITile tile)
    {
        _currenteLife = _life;
        _currentTile = tile;
        _currentTile.SetCurrentPlayer(this);
        _currentItems = new List<IBaseCollectableItem>();
        
        transform.position = _currentTile.Index;
    }

    public virtual void OnCollectItem(IBaseCollectableItem baseCollectableItem)
    {
        if (baseCollectableItem.IsImmediateConsumption)
        {
            //TODO: consume item effect
        }
        else
        {
            _currentItems.Add(baseCollectableItem);
        }
    }
}
