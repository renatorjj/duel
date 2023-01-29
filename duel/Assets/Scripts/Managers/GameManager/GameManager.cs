using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CoreManager _coreManager;

    [SerializeField]
    private StageManager _stageManager;
    
    private void Awake() 
    {
        _coreManager.Init(_stageManager);
    }

    private void Start() 
    {
        _coreManager.GoToCharacterSelection();
    }
}
