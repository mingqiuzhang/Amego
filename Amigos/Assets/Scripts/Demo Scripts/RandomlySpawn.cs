using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlySpawn : MonoBehaviour {

    public GameObject prefab1, prefab2,prefab3,prefab4,prefab5, prefab6;

    public float SpawnRate = 10f;
    public float trapSpawnRate = 10f;

    public Vector3 center;

    public Vector3 size;

    public float m_StartDelay = 3f;

    private WaitForSeconds m_StartWait;

    Vector3 pos1;

    Vector3 pos2;

    Vector3 pos3;

    Vector3 pos4;

    Vector3 pos5;

    Vector3 pos6;

    float nextSpawn = 0f;

    int whatToSpawn;

    public float weaponsNumber = 6;
    public float trapNumber = 6;

    float temp;
    float temp2;

    
    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
    }

    // Update is called once per frame
    void Update () {
        temp = weaponsNumber;
        temp2 = trapNumber;
        RandomSpawn();
	}

    public void RandomSpawn()
    {
        pos1 = center + new Vector3(Random.Range(-size.x, size.x), 2, Random.Range(-size.z + 5, size.z));
        pos2 = center + new Vector3(Random.Range(-size.x, size.x), 2, Random.Range(-size.z + 5, size.z));
        pos5 = center + new Vector3(Random.Range(-size.x, size.x), 2, Random.Range(-size.z + 5, size.z));
        pos6 = center + new Vector3(Random.Range(-size.x, size.x), 2, Random.Range(-size.z + 5, size.z));
        pos3 = center + new Vector3(Random.Range(-size.x, size.x), 0, Random.Range(-size.z + 5, size.z));
        pos4 = center + new Vector3(Random.Range(-size.x, size.x), 0, Random.Range(-size.z + 5, size.z));

        if (Time.time > nextSpawn && temp != 0)
        {
            whatToSpawn = Random.Range(1, 7);
            if (whatToSpawn == 1)
            {
                Instantiate(prefab1, pos2, transform.rotation * Quaternion.Euler(0, 90, 0));
                temp--;
            }
            else if (whatToSpawn == 2)
            {
                Instantiate(prefab2, pos2, Quaternion.identity);
                temp--;
            }
            else if (whatToSpawn == 3)
            {
                Instantiate(prefab1, pos1, transform.rotation * Quaternion.Euler(0, 90, 0));
                temp--;
            }
            else if(whatToSpawn == 4)
            {
                Instantiate(prefab2, pos2, Quaternion.identity);
                temp--;
            }

            else if (whatToSpawn == 5)
            {
                Instantiate(prefab5, pos2, transform.rotation * Quaternion.Euler(0, 90, 0));
                temp--;
            }

            else
            {
                Instantiate(prefab6, pos2, Quaternion.identity);
                temp--;
            }
            nextSpawn = Time.time + SpawnRate;
            temp = weaponsNumber;
        }

        if (Time.time > nextSpawn && temp2 != 0)
        {
            whatToSpawn = Random.Range(1, 5);
            if(whatToSpawn == 1)
            {
                Instantiate(prefab3, pos3, Quaternion.identity);
                temp2--;
            }
            else if(whatToSpawn == 2)
            {
                Instantiate(prefab4, pos4, Quaternion.identity);
                temp2--;
            }
            else if(whatToSpawn == 3)
            {
                Instantiate(prefab3, pos3, Quaternion.identity);
                temp2--;
            }
            else
            {
                Instantiate(prefab4, pos4, Quaternion.identity);
                temp2--;
            }
            nextSpawn = Time.time + trapSpawnRate;
            temp2 = trapNumber;
        }
    }
}
