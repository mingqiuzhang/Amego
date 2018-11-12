using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {

    float timer = 0.0f;
    bool timeStarted = false;
    float seconds;

    //Set A Private Collider As The Collider We Want To Control
    private Collider current_collision;

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
        }

        //Set Player Able To Move After 3 Seconds
        if (seconds >= 2.25)
        {
            current_collision.GetComponent<CharacterMovement_Physics>().set_canMove(true);
            current_collision.GetComponent<CharacterMovement_Physics>().set_canAim(true);
            timeStarted = false;
            timer = 0.0f;
        }
	}


    //This Part Is To Set The Character Kinematic.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {         
            timer = 0.0f;
            current_collision = other;
            other.GetComponent<CharacterMovement_Physics>().set_canMove(false);
            other.GetComponent<CharacterMovement_Physics>().set_canAim(false);
            other.GetComponent<Animator>().SetTrigger("tSlip");
            //Start The Timer, Once 3 Seconds Has Passed The Player Could Move Again. Players Will Slide If They Moved Onto A Banana.
            timeStarted = true;
        }

    }
}
