using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] GameObject _blockPref;
    [SerializeField] public int _maxBlocks = 1;

    List<GameObject> _existBlocks;
    Vector3 _spawnOffset;

    private void Awake()
    {
        _existBlocks = new List<GameObject>();
        _spawnOffset = new Vector3(1, 0, 0);
    }

    public void SpawnBlock(Vector3 playerPos, bool isFlip)
    {
        var block = Instantiate(_blockPref);
        if(_existBlocks.Count > 0)
            _existBlocks[_existBlocks.Count - 1].GetComponent<BlockController>().isLast = false;
        if(isFlip)
        {
            block.transform.position = playerPos - _spawnOffset;
        }
        else
        {
            block.transform.position = playerPos + _spawnOffset;
        }

        _existBlocks.Add(block);
        if(_existBlocks.Count > _maxBlocks)
        {
            Destroy(_existBlocks[0]);
            _existBlocks.RemoveAt(0);
        }
    }
}
