using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private Stage _stagePrefab;

    private Stage _currentStage;
    
    public Stage CurrentStage 
    {
        get 
        {
            return _currentStage;
        }
    }

    public void CreateStage() 
    {
        _currentStage = Instantiate(_stagePrefab);
    }

    public void Clear() 
    {
        _currentStage.Destroy();
    }
}
