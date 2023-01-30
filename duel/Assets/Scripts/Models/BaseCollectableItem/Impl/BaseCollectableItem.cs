using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseCollectableItem : MonoBehaviour, IBaseCollectableItem 
{
    [FormerlySerializedAs("itemIcon")] [SerializeField] private Sprite _itemIcon;
    [SerializeField] protected string _name;
    [SerializeField] protected bool _isImmediateConsumption;
    
    private bool _enabledToCollect;

    public bool IsImmediateConsumption => _isImmediateConsumption;

    public void Init(Vector2 position) 
    {
        transform.position = position;
        _enabledToCollect = true;
    }
    
    protected virtual void OnItemCollect(IPlayer player) 
    {
        if (_enabledToCollect)
        {
            if (player != null && player.CanCollectItem) 
            {
                _enabledToCollect = false;
                player.OnCollectItem(this);
                gameObject.SetActive(false);
                
                Debug.Log($"[BaseCollectableItem][OnItemCollect] Player collected {_name}");
            }
        }
    }
    
    protected void OnTriggerEnter2D(Collider2D collider) 
    {
        var player = collider.GetComponent<IPlayer>();
        OnItemCollect(player);
    }
}
