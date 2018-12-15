using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

    public AudioClip sword_attack;
    public AudioClip bow_attack;
    public AudioClip axe_attack;
    public AudioClip staff_attack;
    private Animator _playerAnimator;
    private CharacterMovement_Physics _character;
    private AudioSource _source;
    private bool canAttack = true;
    Transform _sword;
    Collider _collider_of_sword;

    Transform _axe;
    Collider _collider_of_axe;

    public float axeAttackTime = 2f;
    private float axeAttackCounter;

    private bool axeAttacking = false;
    // Use this for initialization
    void Start () {
        _playerAnimator = this.GetComponent<Animator>();
        _character = this.GetComponent<CharacterMovement_Physics>();
        _sword = this.transform.GetChild(2).GetChild(2);
        _collider_of_sword = _sword.GetComponent<Collider>();
        _collider_of_sword.enabled = false;
        axeAttackCounter = axeAttackTime;

        _axe = this.transform.GetChild(2).GetChild(4);
        _collider_of_axe = _axe.GetComponent<Collider>();
        _collider_of_axe.enabled = false;
    }

    void Awake()
    {
        _source = this.GetComponent<AudioSource>();
    }

    private void StartSwordAttack()
    {
        _collider_of_sword.enabled = true;
        _source.PlayOneShot(sword_attack, (float)0.5);
    }

    private void EndSwordAttack()
    {
        _collider_of_sword.enabled = false;
        canAttack = true;
    }

    private void Axe_Attack_Happens()
    {
        _source.PlayOneShot(axe_attack, (float)1);
    }

    private void FireArrow()
    {
        _source.PlayOneShot(bow_attack, (float)0.5);
        _character.primaryAttack.Fire(_character.attackPoint);
        canAttack = true;
        //primaryAttack.Fire(attackPoint);
    }

    private void Fire_Magic()
    {

        _character.primaryAttack.Fire_Ice(_character.attackPoint);
        canAttack = true;
    }

    public void PlayAttackAnimation(EquipedWeaponSwitch.CurrentWeapon i_weapon)
    {
        switch (i_weapon)
        {
            case EquipedWeaponSwitch.CurrentWeapon.bow:
                if(canAttack == true)
                {
                    _playerAnimator.SetTrigger("tBowAttack");
                    canAttack = false;
                }
                break;
            case EquipedWeaponSwitch.CurrentWeapon.sword:
                if(canAttack == true)
                {
                    _playerAnimator.SetTrigger("tSwordAttack");
                    canAttack = false;
                }
                break;
            case EquipedWeaponSwitch.CurrentWeapon.axe:
                _character._characterVelocity = new Vector3(0, 0, 0);
                _playerAnimator.SetBool("bAxeAttack", true);
                _playerAnimator.applyRootMotion = true;
                axeAttacking = true;
                break;
            case EquipedWeaponSwitch.CurrentWeapon.staff:
                if (canAttack == true)
                {
                    _playerAnimator.SetTrigger("tStaffAttack");
                    canAttack = false;
                }
                break;
        }
    }
	public void SetAnimatorVelocity(float i_velocity)
    {
        _playerAnimator.SetFloat("fVelocity", i_velocity);
    }

    private void Update()
    {
        if (axeAttacking)
        {
            _character.set_canMove(false);
            axeAttackCounter -= Time.deltaTime;
            _collider_of_axe.enabled = true;
            if (axeAttackCounter < 0)
            {
                _collider_of_axe.enabled = false;
                axeAttacking = false;
                _character.set_canMove(true);
                _playerAnimator.SetBool("bAxeAttack", false);
                axeAttackCounter = axeAttackTime;
                _playerAnimator.applyRootMotion = false;
            }
        }
    }
}
