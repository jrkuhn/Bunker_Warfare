using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {
    public static int numEnemies;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        numEnemies = 0;
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        numEnemies += 1;
    }
}
