using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {
    private Animator _playerAnimator;
    private CharacterMovement_Physics _character;

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

    private void StartSwordAttack()
    {
        _collider_of_sword.enabled = true;
    }

    private void EndSwordAttack()
    {
        _collider_of_sword.enabled = false;
    }

    private void FireArrow()
    {
        _character.primaryAttack.Fire(_character.attackPoint);
        //primaryAttack.Fire(attackPoint);
    }

    public void PlayAttackAnimation(EquipedWeaponSwitch.CurrentWeapon i_weapon)
    {
        switch (i_weapon)
        {
            case EquipedWeaponSwitch.CurrentWeapon.bow:
                _playerAnimator.SetTrigger("tBowAttack");
                break;
            case EquipedWeaponSwitch.CurrentWeapon.sword:
                _playerAnimator.SetTrigger("tSwordAttack");
                break;
            case EquipedWeaponSwitch.CurrentWeapon.axe:
                _playerAnimator.SetBool("bAxeAttack", true);
                break;
        }
    }
	public void SetAnimatorVelocity(float i_velocity)
    {
        _playerAnimator.SetFloat("fVelocity", i_velocity);
    }
}
