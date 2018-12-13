using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDead : MonoBehaviour {

    public GameObject character;
    private bool _canDealDamage = false;
    float seconds;
    bool timeStarted = false;
    float timer = 0.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Start Timer
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
            seconds = (float)(timer % 60);
            //Set Player Able To Move After 3 Seconds
            if (seconds >= 2.25)
            {
                character.GetComponent<Rigidbody>().isKinematic = false;
                character.GetComponent<CharacterMovement_Physics>().set_canMove(true);
                character.GetComponent<CharacterMovement_Physics>().set_canAim(true);
                timeStarted = false;
                timer = 0.0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "weapon"))
        {
            character.SetActive(false);
        }
        if ((collision.gameObject.tag == "arrow"))
        {
            character.SetActive(false);
            collision.gameObject.SetActive(false);
            print("Arrow Hit");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "banana"))
        {
            timeStarted = true;
        }
        if ((other.gameObject.tag == "Trap"))
        {
            timeStarted = true;
        }
    }
}
