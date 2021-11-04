using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBlock(Vector3 playerPos, bool isFlip)
    {
        var block = Instantiate(_blockPref);
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
