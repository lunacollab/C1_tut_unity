using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    protected List<GameObject> enemies;
    protected int maxEnemy = 3; // Số enemy tối đa
    protected GameObject enemySpawnPos;
    protected GameObject enemyPrefab;
    protected float timer = 0;
    protected float delay = 2f; // Delay 3 giây giữa các lần spawn
    
    private void Awake()
    {
        this.enemySpawnPos = GameObject.Find("EnemySpawnPos");
        this.enemyPrefab = GameObject.Find("EnemyPrefab");
        this.enemies = new List<GameObject>();
        
        // Debug để kiểm tra references
        if (this.enemySpawnPos == null) Debug.LogError("EnemySpawnPos not found!");
        if (this.enemyPrefab == null) Debug.LogError("EnemyPrefab not found!");
        if (PlayerCtrl.instance == null) Debug.LogError("PlayerCtrl.instance is null!");
        else if (PlayerCtrl.instance.damageReceiver == null) Debug.LogError("PlayerCtrl.damageReceiver is null!");
        
        Debug.Log($"EnemySpawner initialized - SpawnPos: {this.enemySpawnPos != null}, Prefab: {this.enemyPrefab != null}");
    }

    private void Update()
    {
        this.Spawn();
        this.CheckEnemyDead();
    }

    protected virtual void Spawn()
    {   
        // Debug timer
        if (this.timer < this.delay)
        {
            this.timer += Time.deltaTime;
            if (this.timer < this.delay) return;
        }
        
        // Debug các điều kiện spawn
        if (PlayerCtrl.instance == null) 
        {
            Debug.LogError("PlayerCtrl.instance is null - cannot spawn enemy!");
            return;
        }
        
        if (PlayerCtrl.instance.damageReceiver == null) 
        {
            Debug.LogError("PlayerCtrl.damageReceiver is null - cannot spawn enemy!");
            return;
        }
        
        if (PlayerCtrl.instance.damageReceiver.IsDead()) 
        {
            Debug.Log("Player is dead - not spawning enemy");
            return;
        }
        
        if (this.enemies.Count >= this.maxEnemy) 
        {
            Debug.Log($"Max enemies reached ({this.maxEnemy}) - not spawning more");
            return;
        }
        
        if (this.enemySpawnPos == null || this.enemyPrefab == null)
        {
            Debug.LogError("Missing spawn references - cannot spawn enemy!");
            return;
        }
        
        // Reset timer và spawn enemy mới
        this.timer = 0;
        
        // Tạo enemy instance mới từ prefab
        GameObject enemy = Instantiate(this.enemyPrefab);
        Vector3 spawnPos = this.enemySpawnPos.transform.position;
        spawnPos.z = -1f; // Hiển thị trên road
        enemy.transform.position = spawnPos;
        enemy.transform.parent = transform;
        enemy.SetActive(true);
        
        // Đảm bảo enemy hiển thị trên road bằng Sorting Order
        SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();
        if (enemySprite != null)
        {
            enemySprite.sortingOrder = 1; // Hiển thị trên road (sorting order = 0)
            Debug.Log($"Enemy sprite sorting order set to: {enemySprite.sortingOrder}");
        }
        else
        {
            Debug.LogWarning("Enemy does not have SpriteRenderer component!");
        }
        
        this.enemies.Add(enemy);
        
        Debug.Log($"✅ SPAWNED ENEMY! Total enemies: {this.enemies.Count}/{this.maxEnemy}");
        
        // Đảm bảo enemy có thể follow player ngay lập tức
        FollowPlayer followScript = enemy.GetComponent<FollowPlayer>();
        if (followScript != null)
        {
            followScript.player = PlayerCtrl.instance.transform;
        }
    }

    void CheckEnemyDead()
    {
        // Duyệt ngược để tránh lỗi khi remove element
        for (int i = this.enemies.Count - 1; i >= 0; i--)
        {
            if (this.enemies[i] == null)
            {
                this.enemies.RemoveAt(i);
                Debug.Log($"Enemy destroyed! Remaining enemies: {this.enemies.Count}/{this.maxEnemy}");
            }
        }
    }
}
