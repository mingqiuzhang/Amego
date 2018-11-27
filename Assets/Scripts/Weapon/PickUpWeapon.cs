using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour {
    public GameObject myWeaponPlayer1;
    public GameObject myWeaponPlayer2;
    public GameObject myWeaponPlayer3;
    public GameObject myWeaponPlayer4;
    public GameObject groundWeapon;
	// Use this for initialization
	void Start () {
        myWeaponPlayer1.SetActive(false);
	}

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Player")
        {
            myWeaponPlayer1.SetActive(true);
            /*
            var transforms = _collider.GetComponentsInChildren<Transform>();
            foreach (var child in transforms)
            {
                if (child.name == "WeaponManager")
                {
                    //child.gameObject.SetActive(false);
                    
                    var weapons = child.GetComponentsInChildren<Transform>();

                    foreach(var weapon in weapons)
                    {
                        if (weapon.gameObject == groundWeapon)
                        {
                            weapon.gameObject.SetActive(true);
                        }
                    }
                    
                    
                }
            }
            */

            groundWeapon.SetActive(false);
        }

        if (_collider.gameObject.tag == "Player2")
        {
            myWeaponPlayer2.SetActive(true);
            groundWeapon.SetActive(false);
        }
        if (_collider.gameObject.tag == "Player3")
        {
            myWeaponPlayer3.SetActive(true);
            groundWeapon.SetActive(false);
        }
        if (_collider.gameObject.tag == "Player4")
        {
            myWeaponPlayer4.SetActive(true);
            groundWeapon.SetActive(false);
        }
    }
}
