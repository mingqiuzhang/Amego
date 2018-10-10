using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponToBonesTest : MonoBehaviour {
    public GameObject player;
    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "weapon" || _collider.gameObject.tag == "bow")
        {
            _collider.gameObject.transform.parent = player.transform;
            _collider.gameObject.SetActive(true);
        }
    }
}
