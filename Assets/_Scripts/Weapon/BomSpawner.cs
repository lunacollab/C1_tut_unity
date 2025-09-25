using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BomSpawner : Spawner
{
    //[Header("Bomb")]
    private void Start()
    {
        this.objects = new List<GameObject>();
        this.objPrefab = GameObject.Find("BombPrefab");
        this.spawnPos = GameObject.Find("BombSpawnPos");
        this.objPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.Spawn();
        this.CheckMinionDead();
    }
    void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;
        if (this.objects.Count >= 7) return;
        int index = objects.Count + 1;
        GameObject minion = Instantiate(this.objPrefab);
        minion.name = "Bom #" + index;
        minion.transform.position = this.spawnPos.transform.position;
        minion.gameObject.SetActive(true);
        minion.AddComponent<PlayerPosition>();
        this.objects.Add(minion);
    }
    void CheckMinionDead()
    {
        GameObject minion;
        for (int i = 0; i < this.objects.Count; i++)
        {
            minion = this.objects[i];
            if(minion == null) this.objects.RemoveAt(i);
        }
    }
}
