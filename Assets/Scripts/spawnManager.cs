using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(20, 0, 0);
    public float startDelay = 2;
    public float repeatRate = 2;
    private playerController playerControllerScript;
    public float spawnPosX;
    public float spawnPosZ;
    public float spawnRangeYMin = 20;
    public float spawnRangeYMax = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        if (playerControllerScript.isDead == false)
        {
            Vector3 spawnPos = new Vector3(spawnPosX, Random.Range(-spawnRangeYMin, spawnRangeYMax), spawnPosZ);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
