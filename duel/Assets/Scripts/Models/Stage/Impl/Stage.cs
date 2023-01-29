using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour, IStage
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private ItemManager _itemManager;

    private int _xSize;
    private int _ySize;
    
    private Dictionary<Vector2, ITile> _tiles;
    private Dictionary<Vector2, ITile> _activeTiles;

    public ITile GetActiveTile(Vector2 index) => _activeTiles.ContainsKey(index) ? _activeTiles[index] : null;

    public void Init() 
    {        
        _tiles ??= new Dictionary<Vector2, ITile>();
        _activeTiles ??= new Dictionary<Vector2, ITile>();
        _xSize = Random.Range(8, 17);
        _ySize = Random.Range(8, 17);
        InstantiateTiles();
    }

    //TODO: Criar classe Tile
    private void InstantiateTiles()
    {
        for (int i = 0; i < _xSize; i++)
        {
            for (int j = 0; j < _ySize; j++)
            {
                ITile tile;
                var index = new Vector2(i, j);
                if (_tiles.ContainsKey(index))
                {
                    tile = _tiles[index];
                    tile.Init(null);
                }
                else
                {
                    tile = Instantiate(_tilePrefab, index, Quaternion.identity);
                    tile.Init(index);
                }
                
                _activeTiles.Add(index, _tiles[index]);
            }
        }
    }

    public List<Vector2> GetPlayersIndex(int quantityPlayerToBattle)
    {
        List<Vector2> indexs = new List<Vector2>();
        return indexs;
    }

    public void InitItems()
    {
        InstantiateItems();
    }
    
    private void InstantiateItems() 
    {
        foreach (var activeTile in _activeTiles) 
        {
            _itemManager.DropItem(activeTile.Value.Index);
        }
    }

    public void Clear()
    {
        foreach (var tile in _tiles)
        {
            tile.Value.Clear();
        }
        
        _activeTiles.Clear();
    }
}
