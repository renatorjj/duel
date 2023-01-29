using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseCollectableItem : MonoBehaviour, IBaseCollectableItem 
{
    [FormerlySerializedAs("itemIcon")] [SerializeField] private Sprite _itemIcon;
    [SerializeField] private string _name;
    
    private bool _enabledToCollect;

    protected void Awake() 
    {
        _enabledToCollect = true;
    }

    public void Init(Vector2 position) 
    {
        transform.position = position;
    }
    
    protected virtual void OnItemCollect(IPlayer player) 
    {
        if (_enabledToCollect)
        {
            if (player != null && player.CanCollectItem) 
            {
                player.OnCollectItem(this);
                _enabledToCollect = false;
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

    protected void OnTriggerStay2D(Collider2D collider) 
    {
        var player = collider.GetComponent<IPlayer>();
        OnItemCollect(player);
    }
}
