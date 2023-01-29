using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private DropProperty[] _itemDropProperty;

    private Dictionary<string, List<BaseCollectableItem>>  _instantiatedBaseCollectableItemsByName;
    private Dictionary<string, int> _quantityBaseCollectableItemsByName;
    private Dictionary<string, List<BaseCollectableItem>> _activeBaseCollectableItemsByName;

    private void Awake()
    {
        _instantiatedBaseCollectableItemsByName = new Dictionary<string, List<BaseCollectableItem>>();
        _quantityBaseCollectableItemsByName = new Dictionary<string, int>();
        _activeBaseCollectableItemsByName = new Dictionary<string, List<BaseCollectableItem>>();
    }

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

        BaseCollectableItem collectableItem;
        if (_instantiatedBaseCollectableItemsByName != null)
        {
            collectableItem = Pooling(collectableItemPrefab, position);
            collectableItem.Init(position);
        }
        else
        {
            Debug.LogError($"[ItemManager][DropItem] collectableItemPrefab is null");
            DropItem(position);
        }
    }

    private BaseCollectableItem Pooling(BaseCollectableItem collectableItemPrefab, Vector2 position)
    {
        BaseCollectableItem collectableItem = null;
        if (_instantiatedBaseCollectableItemsByName != null)
        {
            string typeName = collectableItemPrefab.name;
            if (_instantiatedBaseCollectableItemsByName.ContainsKey(typeName))
            {
                int instantiatedQuantityByName = _quantityBaseCollectableItemsByName[typeName];
                int activeQuantityByName = _activeBaseCollectableItemsByName[typeName].Count;
                if (instantiatedQuantityByName > activeQuantityByName)
                {
                    int index = (instantiatedQuantityByName - activeQuantityByName) - 1;
                    _activeBaseCollectableItemsByName[typeName]
                        .Add(_instantiatedBaseCollectableItemsByName[typeName][index]);
                }
                else
                {
                    collectableItem = Instantiate(collectableItemPrefab, position, Quaternion.identity);
                    _instantiatedBaseCollectableItemsByName[typeName].Add(collectableItem);
                    _quantityBaseCollectableItemsByName[typeName]++;
                    _activeBaseCollectableItemsByName[typeName].Add(collectableItem);
                }
            }
            else
            {
                collectableItem = Instantiate(collectableItemPrefab, position, Quaternion.identity);
                List<BaseCollectableItem> collectableItems = new List<BaseCollectableItem>();
                collectableItems.Add(collectableItem);
                _instantiatedBaseCollectableItemsByName.Add(typeName, collectableItems);
                _quantityBaseCollectableItemsByName.Add(typeName, 1);
                _activeBaseCollectableItemsByName.Add(typeName, collectableItems);
            }
        }
        else
        {
            Debug.LogError($"[ItemManager][DropItem] collectableItemPrefab is null");
            DropItem(position);
        }
        
        return collectableItem;
    }

    public void Clear()
    {
        foreach (var baseCollectableItemsByName in _instantiatedBaseCollectableItemsByName)
        {
            for (int i = 0; i < baseCollectableItemsByName.Value.Count; i++)
            {
                baseCollectableItemsByName.Value[i].gameObject.SetActive(false);
            }
        }

        _activeBaseCollectableItemsByName.Clear();
    }
}
