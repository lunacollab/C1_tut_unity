using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Enemy")]
    protected int maxEnemy = 3; 
    
    private void Awake()
    {
        this.spawnPos = GameObject.Find("EnemySpawnPos");
        this.objPrefab = GameObject.Find("EnemyPrefab");
        this.objects = new List<GameObject>();
    }

    private void Update()
    {
        this.Spawn();
        this.CheckEnemyDead();
    }

    protected virtual void Spawn()
    {   

        if (this.spawnTimer < this.spawnDelay)
        {
            this.spawnTimer += Time.deltaTime;
            if (this.spawnTimer < this.spawnDelay) return;
        }
        
        this.spawnTimer = 0;
        
        GameObject enemy = Instantiate(this.objPrefab);
        Vector3 spawnPos = this.spawnPos.transform.position;
        spawnPos.z = -1f;
        enemy.transform.position = spawnPos;
        enemy.transform.parent = transform;
        enemy.SetActive(true);

        SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();
        if (enemySprite != null)
        {
            enemySprite.sortingOrder = 1;
        }
         
        this.objects.Add(enemy);

        FollowPlayer followScript = enemy.GetComponent<FollowPlayer>();
        if (followScript != null)
        {
            followScript.player = PlayerCtrl.instance.transform;
        }
    }

    void CheckEnemyDead()
    {
        for (int i = this.objects.Count - 1; i >= 0; i--)
        {
            if (this.objects[i] == null)
            {
                this.objects.RemoveAt(i);
            }
        }
    }
}
