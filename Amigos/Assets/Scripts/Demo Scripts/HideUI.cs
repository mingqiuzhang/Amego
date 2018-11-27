using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour {
    public float after = 2f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(after);
        gameObject.SetActive(false);
    }
}
