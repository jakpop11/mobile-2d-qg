using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] float spawnfrequency = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1, spawnfrequency);
    }

    void SpawnObstacle()
    {
        Vector3 randomPos = new Vector3 (transform.position.x, Random.Range(-3, 3), transform.position.z);

        Instantiate(obstacle, randomPos, transform.rotation);
    }
}
