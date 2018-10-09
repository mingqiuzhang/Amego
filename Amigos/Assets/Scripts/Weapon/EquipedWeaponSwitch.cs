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
        if (_collider.gameObject.tag == "weapon" || _collider.gameObject.tag == "bow")
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
