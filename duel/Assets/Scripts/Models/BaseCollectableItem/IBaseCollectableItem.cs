using UnityEngine;

public interface IBaseCollectableItem
{
    void Init(Vector2 position);
    bool IsImmediateConsumption { get; }
}
