using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseCollectableItem : MonoBehaviour, IBaseCollectableItem 
{
    [FormerlySerializedAs("itemIcon")] [SerializeField]
    private Sprite _itemIcon;

    private bool _enabledToCollect;

    protected void Awake() 
    {
        _enabledToCollect = false;
    }

    protected void Update() 
    {
        if (!_enabledToCollect) 
        {
            _enabledToCollect = true;
        }    
    }

    //TODO: Criar classe Player
    protected void OnTriggerEnter2D(Collider2D collider) 
    {
        // IPlayer player = collider.GetComponent<IPlayer>();
        // OnItemCollect(player);
    }

    protected void OnTriggerStay2D(Collider2D collider) 
    {
        // IPlayer player = collider.GetComponent<IPlayer>();
        // OnItemCollect(player);
    }


    public void Init(Vector2 position) 
    {
        transform.position = position;
    }

    //TODO: Coletar item
    // private void OnItemCollect(IPlayer player) 
    // {
    //     if (_enabledToCollect)
    //     {
    //         
    //         if (player != null && player.CanCollectItem(this)) 
    //         {
    //             player.OnCollectItem(this);
    //             Destroy(gameObject);
    //         }
    //     }
    // }
}
