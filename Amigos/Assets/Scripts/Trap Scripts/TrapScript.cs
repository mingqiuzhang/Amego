using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {

    public AudioClip slip_sound;
    //Set A Private Collider As The Collider We Want To Control
    private Collider current_collision;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

    //This Part Is To Set The Character Kinematic.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {
            print("steped on banana");

            current_collision = other;
            other.GetComponent<CharacterMovement_Physics>().set_canMove(false);
            other.GetComponent<CharacterMovement_Physics>().set_canAim(false);
            other.GetComponent<Animator>().SetTrigger("tSlip");
            //Start The Timer, Once 3 Seconds Has Passed The Player Could Move Again. Players Will Slide If They Moved Onto A Banana.
            other.GetComponent<AudioSource>().PlayOneShot(slip_sound, (float)0.7);
        }

    }
}
