using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float timerSet = 7;
    private float timeRemaining = 1;
    //public float maxBalls = 10;
    //private float totalBalls = 0;

// Update is called once per frame
    void Spawn()
    {
        GameObject cloneBall = (GameObject)Instantiate(ballPrefab, transform.position, transform.rotation);
        //totalBalls++;
        timeRemaining = timerSet;
       // if (totalBalls >= maxBalls) { Destroy(cloneBall); }
    }
    void Update()
    {
    timeRemaining -= Time.deltaTime;
    if(timeRemaining <= 0)
        {
            Spawn();
        }
    }
}
