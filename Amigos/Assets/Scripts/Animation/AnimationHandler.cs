using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

    public AudioClip sword_attack;
    public AudioClip bow_attack;
    private Animator _playerAnimator;
    private CharacterMovement_Physics _character;
    private AudioSource _source;
    private bool canAttack = true;
    Transform _sword;
    Collider _collider_of_sword;
    // Use this for initialization
    void Start () {
        _playerAnimator = this.GetComponent<Animator>();
        _character = this.GetComponent<CharacterMovement_Physics>();
        _sword = this.transform.GetChild(2).GetChild(2);
        _collider_of_sword = _sword.GetComponent<Collider>();
        _collider_of_sword.enabled = false;
       
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

    private void FireArrow()
    {
        _source.PlayOneShot(bow_attack, (float)0.5);
        _character.primaryAttack.Fire(_character.attackPoint);
        canAttack = true;
        //primaryAttack.Fire(attackPoint);
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
                _playerAnimator.SetBool("bAxeAttack", true);
                break;
            case EquipedWeaponSwitch.CurrentWeapon.staff:
                _playerAnimator.SetTrigger("tStaffAttack");
                break;
        }
    }
	public void SetAnimatorVelocity(float i_velocity)
    {
        _playerAnimator.SetFloat("fVelocity", i_velocity);
    }
}
