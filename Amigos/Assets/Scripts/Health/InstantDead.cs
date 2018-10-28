using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDead : MonoBehaviour {

    public GameObject character;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            character.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }


}
