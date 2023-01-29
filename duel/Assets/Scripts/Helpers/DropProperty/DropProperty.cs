using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class DropProperty 
{
    [SerializeField] private BaseCollectableItem _itemPrefab;
    [FormerlySerializedAs("dropRate")] [SerializeField] [Range(0, 100)] private float _dropRate;
    
    public BaseCollectableItem ItemPrefab 
    {
        get 
        {            
            return _itemPrefab;
        }
    }

    public float DropRate 
    {
        get 
        {
            return _dropRate;
        }
    }
}
