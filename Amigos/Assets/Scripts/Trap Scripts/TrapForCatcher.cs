using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapForCatcher : MonoBehaviour {

    float timer = 0.0f;
    bool timeStarted = false;
    int seconds;

    //Set A Private Collider As The Collider We Want To Control
    private Collider current_collision;
    private Rigidbody current_rigi;
    private Vector3 _storedVelocity = Vector3.zero;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Start Timer
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
        }

        //Set Player Able To Move After 3 Seconds
        if (seconds == 3)
        {

            current_collision.GetComponent<Rigidbody>().isKinematic = false;
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

            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<CharacterMovement_Physics>().set_canAim(false);
            other.GetComponent<Animator>().SetTrigger("tSlip");

            //Start The Timer, Once 3 Seconds Has Passed The Player Could Move Again. Players Will Be Freezed If They Step On A Catcher
            timeStarted = true;
        }

        animator.SetTrigger("tActivate");
    }
}
