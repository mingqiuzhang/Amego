using System;
using UnityEngine;

[Serializable]
public class PlayerManager
{
    public Color m_PlayerColor;                             // This is the color this Player will be tinted.
    public Transform m_SpawnPoint;                          // The position and direction the Players will have when it spawns.
    [HideInInspector] public int m_PlayerNumber;            // This specifies which player this the manager for.
    [HideInInspector] public string m_ColoredPlayerText;    // A string that represents the player with their number colored to match their player.
    [HideInInspector] public GameObject m_Instance;         // A reference to the instance of the player when it is created.
    [HideInInspector] public int m_Wins;                    // The number of wins this player has so far.
    [HideInInspector] public int player_lives;

    private CharacterMovement_Physics m_Movement;                        // Used to disable and enable control.
    private Weapon_Projectile m_Shooting;                        // Used to disable and enable control.
    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.
    private EquipedWeaponSwitch m_Weapon;
    private InstantDead m_instantDead;

    public void Setup()
    {
        // Get references to the components.
        m_Movement = m_Instance.GetComponent<CharacterMovement_Physics>();
        m_Shooting = m_Instance.GetComponent<Weapon_Projectile>();
        m_Weapon = m_Instance.GetComponent<EquipedWeaponSwitch>();
        m_instantDead = m_Instance.GetComponent<InstantDead>();
        //m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        // Set the player numbers to be consistent across the scripts.
        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        // Create a string using the correct color that says 'PLAYER 1' etc based on the player's color and the player's number.
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        // Get all of the renderers of the player.
        //MeshRenderer renderers = m_Instance.GetComponent<MeshRenderer>();

        //renderers.material.SetColor("_Color", Color.green);
        //renderers.material.color = m_PlayerColor;
        /*
        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++)
        {
            // ... set their material color to the color specific to this player.
            renderers[i].material.color = m_PlayerColor;
        }
        */
    }


    // Used during the phases of the game where the player shouldn't be able to control their player.
    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;
        foreach(GameObject i in m_Weapon.current)
        {
            i.SetActive(false);
        }

        //m_CanvasGameObject.SetActive(false);
    }


    // Used during the phases of the game where the player should be able to control their player.
    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        //m_CanvasGameObject.SetActive(true);
    }


    // Used at the start of each round to put the player into it's default state.
    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}