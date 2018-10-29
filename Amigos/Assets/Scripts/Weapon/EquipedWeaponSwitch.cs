using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedWeaponSwitch : MonoBehaviour
{

    public GameObject[] current;

    [HideInInspector]
    public enum CurrentWeapon { bow, sword, axe, staff };
    [HideInInspector]
    public static CurrentWeapon weapon;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "GroundWeapon" || _collider.gameObject.tag == "bow")
        {
            foreach (GameObject i in current)
            {
                print(_collider.name);

                if (i.name != _collider.name)
                {
                    i.SetActive(false);
                }
                else
                {
                    if (_collider.name == "bow")
                    {
                        weapon = CurrentWeapon.bow;
                        Weapon_Projectile.Enable();
                    }
                    else if (_collider.name == "staff")
                    {
                        weapon = CurrentWeapon.staff;
                    }
                    else if (_collider.name == "axe")
                    {
                        weapon = CurrentWeapon.axe;
                    }
                    else if (_collider.name == "sword")
                    {
                        weapon = CurrentWeapon.sword;
                    }
                    print(_collider.name);
                    i.SetActive(true);
                }
            }
            _collider.gameObject.SetActive(false);
        }
    }
}