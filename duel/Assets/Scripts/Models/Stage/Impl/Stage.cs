using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour, IStage
{
    [SerializeField]
    private ItemManager _itemManager;
    
    //private List<Tiles> _tiles;

    private void Awake() 
    {        
        InstantiateItems();
    }

    public void Destroy() 
    {
        GameObject.Destroy(gameObject);
    }

    //TODO: Criar classe Tile
    private void InstantiateItems() 
    {
        // _tiles = new List<Tiles>();
        // Tiles[] tiles = GetComponentsInChildren<Tiles>();
        // foreach (var tile in tiles) {
        //     _itemManager.DropItem(tile.position);
        // }
    }
}
