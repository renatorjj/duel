using UnityEngine;

public interface IPlayer
{
    void Init(Vector2 index);
    void OnCollectItem(IBaseCollectableItem baseCollectableItem);
    
    Vector2 CurrentIndex { get; }
    bool CanCollectItem { get; } 
}
