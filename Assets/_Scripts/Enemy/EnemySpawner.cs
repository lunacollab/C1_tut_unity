using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    protected List<GameObject> enemies;
    protected int maxEnemy = 1;
    protected GameObject enemyPrefab;
    protected float timer = 0;
    protected float delay = 2f;
    
    private void Awake()
    {
        this.enemyPrefab = GameObject.Find("EnemyPrefab");
        this.enemyPrefab.SetActive(false);
    }

    private void Update()
    {
        this.Spawn();
    }

    protected virtual void Spawn()
    {   
        if(PlayerCtrl.instance.damageReceiver.IsDead()) return;
        this.timer += Time.deltaTime;
        if(this.timer < this.delay) return;
        this.timer = 0;
        GameObject enemy = Instantiate(this.enemyPrefab);
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
        this.enemies.Add(enemy);
    }
}
