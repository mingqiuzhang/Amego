using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedWeaponSwitch : MonoBehaviour {

    public GameObject[] current;
	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter(Collider _collider)
    {
<<<<<<< HEAD
        if (_collider.gameObject.tag == "GroundWeapon")
=======
        if (_collider.gameObject.tag == "weapon" || _collider.gameObject.tag == "bow")
>>>>>>> e4eadc2e4c0992ccbebfc5be3dd8d95291ef0dcb
        {
            foreach (GameObject i in current)
            {
                if (i.active && i.name != _collider.name)
                {
                    i.SetActive(false);
                }
            }
        }
    }
}
