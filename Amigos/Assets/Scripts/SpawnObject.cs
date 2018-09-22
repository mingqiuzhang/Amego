using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour {
    public Transform[] spawnLocations;
    public GameObject[] spawnPrefeb;
    public GameObject[] spawnClone;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        spawnClone[0] = Instantiate(spawnPrefeb[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        spawnClone[1] = Instantiate(spawnPrefeb[1], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        spawnClone[2] = Instantiate(spawnPrefeb[2], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        spawnClone[3] = Instantiate(spawnPrefeb[3], spawnLocations[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

}
