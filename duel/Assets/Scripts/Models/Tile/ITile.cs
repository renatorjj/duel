using UnityEngine;

public interface ITile
{
    void Init(Vector2? index);
    void Clear();
    void SetCurrentPlayer(IPlayer player);
    
    Vector2 Index { get; }
    bool IsActive { get; }
    IPlayer CurrentPlayer { get; }
    bool CanMove { get; }
}
