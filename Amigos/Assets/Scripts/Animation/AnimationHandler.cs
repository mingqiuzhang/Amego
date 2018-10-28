using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {
    private Animator _playerAnimator;

    // Use this for initialization
    void Start () {
        _playerAnimator = this.GetComponent<Animator>();

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
