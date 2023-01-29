using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayer
{
    [SerializeField] [Range(50, 100)] protected  int _life;
    
    protected Vector2 _currentIndex;
    protected  List<IBaseCollectableItem> _currentItems;

    public Vector2 CurrentIndex => _currentIndex;
    public bool CanCollectItem => _life > 0;
    
    public void Init(Vector2 index)
    {
        _currentIndex = index;
        transform.position = _currentIndex;
        _currentItems = new List<IBaseCollectableItem>();
    }

    public virtual void OnCollectItem(IBaseCollectableItem baseCollectableItem)
    {
        _currentItems.Add(baseCollectableItem);
    }
}
