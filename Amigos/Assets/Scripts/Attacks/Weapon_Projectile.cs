using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon_Projectile : Weapon {

    void Start()
    {
        projectilePrefab = AssetDatabase.LoadAssetAtPath("Assets/prefebs/arrow.prefab", typeof(GameObject));
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
        if (_collision.gameObject.tag == "weapon")
        {
            _canFire = false;
        }

        else if (_collision.gameObject.tag == "bow")
        {
            _canFire = true;
        }
    }
    public Object projectilePrefab; 

    public float fireRate = 0.25f;

    public bool _canFire = true;
    private int uses = 3;

    public override void Fire (Transform attackSpawnPoint)
    {

        if (!_canFire||uses==0) return;

        GameObject projectile = (GameObject)Instantiate(projectilePrefab, attackSpawnPoint.position, attackSpawnPoint.rotation, null);

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
}
