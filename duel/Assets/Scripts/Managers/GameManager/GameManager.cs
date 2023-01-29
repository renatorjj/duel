using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoreManager _coreManager;
    [SerializeField] private StageManager _stageManager;
    [SerializeField] private PlayerManager _playerManager;
    
    private void Awake() 
    {
        _coreManager.Init(_stageManager, _playerManager);
    }

    private void Start() 
    {
        _coreManager.GoToCharacterSelection();
    }
}
