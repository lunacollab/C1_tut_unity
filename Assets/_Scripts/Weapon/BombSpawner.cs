using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BombSpawner : Spawner
{
    private void Reset()
    {
        this.spawnPosName = "BombSpawnPos";
        this.prefabName = "BombPrefab";
        this.maxObj = 7;
    }
    // Update is called once per frame
   
   
}
