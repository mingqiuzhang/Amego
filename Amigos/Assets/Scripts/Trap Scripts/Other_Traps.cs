using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other_Traps : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //This Part Is To Set The Character Kinematic.
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {
            other.gameObject.SetActive(false);
        }
    }
}
