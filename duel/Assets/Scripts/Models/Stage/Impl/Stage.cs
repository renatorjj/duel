using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        _xSize = Random.Range(8, 16);
        _ySize = Random.Range(8, 16);
        PoolingTiles();
    }
    
    private void PoolingTiles()
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

    public List<ITile> GetStartedPlayersIndex(int quantityPlayersToBattle)
    {
        var tiles = new List<ITile>();
        var possibilities = new List<(int, int)>{ (0, 0), (_xSize, 0), (0, _ySize), (_xSize, _ySize) };
        while (tiles.Count < quantityPlayersToBattle)
        {
            int index = Random.Range(0, possibilities.Count);
            var position = new Vector2(possibilities[index].Item1, possibilities[index].Item2);
            var tile = GetActiveTile(position);
            if (tiles.Contains(tile))
            {
                continue;
            }
            
            tiles.Add(tile);
        }

        return tiles;
    }

    public void InitItems()
    {
        InstantiateItems();
    }
    
    private void InstantiateItems() 
    {
        foreach (var activeTile in _activeTiles) 
        {
            if (activeTile.Value.CurrentPlayer != null)
            {
                continue;
            }
            
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
        _itemManager.Clear();
    }
}
