using UnityEngine;

abstract public class Weapon : MonoBehaviour 
{
    public abstract void Fire(Transform attackSpawnPoint);
    public abstract void Fire_Ice(Transform attackSpawnPoint);
}
