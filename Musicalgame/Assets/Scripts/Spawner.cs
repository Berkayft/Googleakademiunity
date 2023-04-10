using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnInterval = 30f; // asker do�urma aral���
    public GameObject enemyPrefab; // asker prefab'�
    public Transform enemySpawn; // asker do�urma konumu
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // asker do�urmak i�in timer'� kontrol et
        if (spawnTimer <= 0f)
        {
            SpawnEnemy(); // asker do�ur
            spawnTimer = spawnInterval; // asker do�urma aral���n� s�f�rla
        }
        else
        {
            spawnTimer -= Time.deltaTime; // timer'� azalt
        }
    }


    private void SpawnEnemy()
    {
        // asker prefab'�ndan bir tane olu�tur
        Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
    }
}
