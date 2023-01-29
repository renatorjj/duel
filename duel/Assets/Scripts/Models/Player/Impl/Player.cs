using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private Vector2 _currentIndex;
    public void Init(Vector2 index)
    {
        _currentIndex = index;
        transform.position = _currentIndex;
    }
}
