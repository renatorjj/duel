using UnityEngine;

public interface ITile
{
    void Init(Vector2? index);
    void Clear();
    bool CanMove();
    void SetPlayer(IPlayer player);
    
    Vector2 Index { get; }
    bool IsActive { get; }
    IPlayer Player { get; }
}
