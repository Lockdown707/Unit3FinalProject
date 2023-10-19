using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float speed = 30f;
    private playerController playerControllerScript;
    private float backBound = -20;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isDead == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (transform.position.z < backBound && gameObject.CompareTag("obstaclePrefab"))
        {
            Destroy(gameObject);
        }
    }
}