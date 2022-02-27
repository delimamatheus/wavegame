using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public float timeController;
    public float spawnTime = 5;

    void Update()
    {
        timeController += Time.deltaTime;
        if(timeController > spawnTime)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(7,-9),1,37);
            Instantiate(enemy,randomSpawnPosition,Quaternion.identity);
            timeController = 0;
        }
    }
}   
