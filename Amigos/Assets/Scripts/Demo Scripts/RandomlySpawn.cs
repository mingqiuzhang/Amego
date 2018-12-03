using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlySpawn : MonoBehaviour {

    public GameObject prefab1, prefab2, prefab3, prefab4;

    public float spawnRate = 10f;

    public Vector3 center;

    public Vector3 size;

    public float m_StartDelay = 3f;

    private WaitForSeconds m_StartWait;

    Vector3 pos1;

    Vector3 pos2;

    Vector3 pos3;

    Vector4 pos4;

    float nextSpawn = 0f;

    int whatToSpawn;

    public float spawnedNumber = 6;
    public float trapNumber = 5;

    float temp;
    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        temp = spawnedNumber;

        for (int i = 0; i < trapNumber; i++)
        {
            pos3 = center + new Vector3(Random.Range(-size.x, size.x), (float) 0.5, Random.Range(-size.z, size.z));
            pos4 = center + new Vector3(Random.Range(-size.x, size.x), (float) 0.5, Random.Range(-size.z, size.z));
            Instantiate(prefab3, pos3, Quaternion.identity);
            Instantiate(prefab4, pos4, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update () {
        RandomSpawn();
	}

    public void RandomSpawn()
    {
        pos1 = center + new Vector3(Random.Range(-size.x, size.x), 2, Random.Range(-size.z, size.z));
        pos2 = center + new Vector3(Random.Range(-size.x, size.x), 2, Random.Range(-size.z, size.z)); 
        

        if (Time.time > nextSpawn && temp != 0)
        {
            whatToSpawn = Random.Range(1, 2);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(prefab1, pos1, Quaternion.identity);
                    temp--;
                    break;
                case 2:
                    Instantiate(prefab2, pos2, Quaternion.identity);
                    temp--;
                    break;
            }
            nextSpawn = Time.time + spawnRate;
            temp = spawnedNumber;
        }
    }
}
