using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour {
    public GameObject myWeapon;
    public GameObject groundWeapon;
	// Use this for initialization
	void Start () {
        myWeapon.SetActive(false);
	}

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Player")
        {
            myWeapon.SetActive(true);
            groundWeapon.SetActive(false);
        }
    }
}
