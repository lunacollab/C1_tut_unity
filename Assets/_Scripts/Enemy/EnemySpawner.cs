using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
 
    private void Reset()
    {
        this.spawnPosName = "EnemySpawnPos";
        this.prefabName = "EnemyPrefab";
    }

}
