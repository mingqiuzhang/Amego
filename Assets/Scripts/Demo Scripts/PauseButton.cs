using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    bool pauseGame = false;

	// Update is called once per frame
	void Update () {

        if (pauseGame == false)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

        if (Input.GetKey(KeyCode.Pause))
        {
            if (pauseGame == true)
                pauseGame = false;
            else
                pauseGame = true;
        }

	}
}
