using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnInterval = 30f; // asker doðurma aralýðý
    public GameObject enemyPrefab; // asker prefab'ý
    public Transform enemySpawn; // asker doðurma konumu
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // asker doðurmak için timer'ý kontrol et
        if (spawnTimer <= 0f)
        {
            SpawnEnemy(); // asker doður
            spawnTimer = spawnInterval; // asker doðurma aralýðýný sýfýrla
        }
        else
        {
            spawnTimer -= Time.deltaTime; // timer'ý azalt
        }
    }


    private void SpawnEnemy()
    {
        // asker prefab'ýndan bir tane oluþtur
        Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
    }
}
