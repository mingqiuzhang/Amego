using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {
    private Animator _playerAnimator;
    private CharacterMovement_Physics _character;
    // Use this for initialization
    void Start () {
        _playerAnimator = this.GetComponent<Animator>();
        _character = this.GetComponent<CharacterMovement_Physics>();
    }

    public void StartSwordAttack()
    {
        print("Sword dealing damage now");
    }

    public void EndSwordAttack()
    {
        print("Sword not dealing damage now");
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
