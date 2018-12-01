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

    private Weapon_Projectile _weapon_pro;
    // Use this for initialization
    void Start()
    {
        _weapon_pro = this.GetComponent<Weapon_Projectile>();
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "sword" || _collider.gameObject.tag == "bow")
        {
            foreach (GameObject i in current)
            {

                if (i.name != _collider.gameObject.tag)
                {
                    i.SetActive(false);
                }
                else
                {
                    if (_collider.gameObject.tag == "bow")
                    {
                        weapon = CurrentWeapon.bow;
                        _weapon_pro.Enable(); 
                    }
                    else if (_collider.gameObject.tag == "staff")
                    {
                        weapon = CurrentWeapon.staff;
                    }
                    else if (_collider.gameObject.tag == "axe")
                    {
                        weapon = CurrentWeapon.axe;
                    }
                    else if (_collider.gameObject.tag == "sword")
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