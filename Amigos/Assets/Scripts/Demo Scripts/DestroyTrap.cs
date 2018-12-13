using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrap : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Trap" || collider.gameObject.tag == "banana")
        {
            Destroy(collider.gameObject);
        }
    }
}
