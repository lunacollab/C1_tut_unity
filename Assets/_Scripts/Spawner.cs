
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]   
    public GameObject objPrefab;

    public GameObject spawnPos;
    public List<GameObject> objects;

    public float spawnTimer = 0;
    public float spawnDelay = 1f;
}