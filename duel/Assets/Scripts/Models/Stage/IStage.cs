using System.Collections.Generic;
using UnityEngine;

public interface IStage
{
    void Init();
    void InitItems();
    void Clear();
    ITile GetActiveTile(Vector2 index);
    List<Vector2> GetPlayersIndex(int quantityPlayerToBattle);
}
