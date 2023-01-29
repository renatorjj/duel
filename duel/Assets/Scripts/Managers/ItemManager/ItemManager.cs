using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private DropProperty[] _itemDropProperty;

    public void DropItem(Vector2 position) 
    {
        BaseCollectableItem collectableItemPrefab = null;
        while (collectableItemPrefab == null)
        {
            if (collectableItemPrefab == null) 
            {
                int randomItemIndex = Random.Range(0, _itemDropProperty.Length);
                DropProperty itemDropProperty = _itemDropProperty[randomItemIndex];
                float itemDropChance = Random.Range(0f, 100f);
            
                if (itemDropChance <= itemDropProperty.DropRate) 
                {
                    collectableItemPrefab = itemDropProperty.ItemPrefab;
                }
            } 
        }

        if (collectableItemPrefab != null) 
        {
            Instantiate(collectableItemPrefab, position, Quaternion.identity);
        }
    }
}
