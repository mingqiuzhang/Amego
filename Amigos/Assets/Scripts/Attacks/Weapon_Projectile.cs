﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon_Projectile : Weapon {

    public int m_PlayerNumber = 4;

    void Start()
    {
        _canFire = false;
        //projectilePrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefebs/arrow.prefab", typeof(GameObject));
        //projectilePrefab = Resources.Load("Assets/prefebs/arrow.prefab");
    }
    void Update()
    {
        if (uses == 0)
        {
            _canFire = false;
        }
    }

    void OnTriggerEnter(Collider _collision)
    {
        if (_collision.gameObject.tag == "GroundWeapon")
        {
            _canFire = false;
        }

        else if (_collision.gameObject.tag == "bow" || _collision.gameObject.tag == "staff")
        {
            _canFire = true;
            uses = 3;
            print(uses);
        }
    }
    public Object projectilePrefab;
    public Object _Magic_Rod_Ice;

    public float fireRate = 0.25f;

    public bool _canFire = true;

    private int uses = 3;

    public override void Fire (Transform attackSpawnPoint)
    {

        if (!_canFire) return;

        GameObject projectile = (GameObject)Instantiate(projectilePrefab, attackSpawnPoint.position, attackSpawnPoint.rotation, null);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 12;
        _canFire = false;

        StartCoroutine(AttackCooldown());

        uses--;
    }

    public override void Fire_Ice(Transform attackSpawnPoint)
    {

        if (!_canFire) return;

        GameObject projectile = (GameObject)Instantiate(_Magic_Rod_Ice, attackSpawnPoint.position, attackSpawnPoint.rotation, null);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 12;
        _canFire = false;

        StartCoroutine(AttackCooldown());

        uses--;
    }

    public IEnumerator AttackCooldown ()
    {
        yield return new WaitForSeconds(fireRate);

        _canFire = true;
    }

    public void Enable()
    {
        _canFire = true;
    }

    public void Disable()
    {
        _canFire = false;
    }
}
