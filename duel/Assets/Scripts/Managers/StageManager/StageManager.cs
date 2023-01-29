using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Stage _stagePrefab;

    private Stage _currentStage;
    
    public Stage CurrentStage => _currentStage;

    public void CreateStage() 
    {
        _currentStage ??= Instantiate(_stagePrefab);
        _currentStage.Init();
    }

    public void Clear() 
    {
        _currentStage.Clear();
    }
}
