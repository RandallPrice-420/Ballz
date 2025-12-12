using System.Collections.Generic;
using UnityEngine;


public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Block       _blockPrefab;

    private List<Block> _blocksSpawned = new List<Block>();

    private int   _rowsSpawned;
    private int   _playWidth             = 8;
    private float _distanceBetweenBlocks = 0.7f;


    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            SpawnRowOfBlocks();
        }

    }   // OnEnable()


    public void SpawnRowOfBlocks()
    {
        foreach (var block in this._blocksSpawned)
        {
            if (block != null)
            {
                block.transform.position += Vector3.down * this._distanceBetweenBlocks;
            }
        }

        for (int i = 0; i < this._playWidth; i++)
        {
            if (UnityEngine.Random.Range(0, 100) > 30)
            {
                continue;
            }

            var block = Instantiate(this._blockPrefab, GetPosition(i), Quaternion.identity);
            int hits  = UnityEngine.Random.Range(1, 3) + this._rowsSpawned;

            block.SetHits(hits);

            this._blocksSpawned.Add(block);
        }

        this._rowsSpawned++;

    }   // SpawnRowOfBlocks()


    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position        += Vector3.right * i * this._distanceBetweenBlocks;
        return position;

    }   // GetPosition()


}   // class BlockSpawner
