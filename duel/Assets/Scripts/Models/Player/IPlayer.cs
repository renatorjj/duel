using UnityEngine;

public interface IPlayer
{
    void Init(ITile tile);
    void OnCollectItem(IBaseCollectableItem baseCollectableItem);
    
    Vector2 CurrentIndex { get; }
    bool CanCollectItem { get; } 
}
