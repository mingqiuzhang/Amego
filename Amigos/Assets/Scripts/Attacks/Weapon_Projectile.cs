using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon_Projectile : Weapon {

    public int m_PlayerNumber = 4;

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
        if (_collision.gameObject.tag == "GropundWeapon")
        {
            _canFire = false;
        }

        else if (_collision.gameObject.tag == "bow")
        {
            _canFire = true;
            uses = 3;
            print(uses);
        }
    }
    public Object projectilePrefab; 

    public float fireRate = 0.25f;

    public static bool _canFire = true;

    private int uses = 3;

    public override void Fire (Transform attackSpawnPoint)
    {

        if (!_canFire) return;

        GameObject projectile = (GameObject)Instantiate(projectilePrefab, attackSpawnPoint.position, attackSpawnPoint.rotation, null);

        _canFire = false;

        StartCoroutine(AttackCooldown());

        uses--;
        print(uses);
    }

    public IEnumerator AttackCooldown ()
    {
        yield return new WaitForSeconds(fireRate);

        _canFire = true;
    }

    public static void Enable()
    {
        _canFire = true;
    }
}
