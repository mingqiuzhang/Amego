using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDead : MonoBehaviour {

    public GameObject character;
    public AudioClip _death_sound;
    private AudioSource _source;
    private Animator _playerAnimator;
    private bool _canDealDamage = false;
    float seconds;
    bool timeStarted = false;
    float timer = 0.0f;
    public float despawnTime = 5f;
    private float despawnCounter;
    private bool playerDead;
    // Use this for initialization
    void Start () {
        despawnCounter = despawnTime;
        _playerAnimator = GetComponent<Animator>();

    }

    void Awake()
    {

        _source = this.GetComponent<AudioSource>();
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

        if (playerDead)
        {
            character.GetComponent<Rigidbody>().isKinematic = true;
            character.GetComponent<CharacterMovement_Physics>().set_canAim(false);
            despawnCounter -= Time.deltaTime;
            if (despawnCounter < 0)
            {
                character.GetComponent<Rigidbody>().isKinematic = false;
                character.GetComponent<CharacterMovement_Physics>().set_canAim(true);
                character.SetActive(false);
                despawnCounter = despawnTime;
                playerDead = false;
            }
        }
    }

    private void PlayerDead()
    {
        _source.PlayOneShot(_death_sound, (float)0.5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "weapon") || (collision.gameObject.tag == "arrow"))
        {
            _playerAnimator.SetTrigger("tDeath");
            playerDead = true;
            
            if (collision.gameObject.tag == "arrow")
            {
                collision.gameObject.SetActive(false);
            }
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
