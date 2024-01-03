using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Rigidbody[] enemyPrefabs;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Rigidbody enemyRb = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
            spawnPoint.position, spawnPoint.rotation);
        enemyRb.AddForce(enemyRb.transform.forward * 3f, ForceMode.Impulse);
    }
}
