using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] players;

    void Update()
    {
        if (players.Length == 1)
        {
            if (players[0].GetComponent<Player>().WinCounts == 3)
            {
                SceneLoader(4);
            }
            SceneLoader(Random.Range(1, 3));
        }
    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
