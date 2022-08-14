using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacles;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController playerController;

    void Start()
    {
        InvokeRepeating("SpawnObjects", startDelay, repeatDelay);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObjects()
    {
        if (!playerController.isGameOver)
        {
            Instantiate(obstacles, spawnPos, Quaternion.identity);
        }

    }
}
