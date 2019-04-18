using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour{

    public Sprite sprite;
    public Transform[] shootPoints;
    public GameObject bullet;

    [Header("Weapon Properties")]
    [Tooltip("bullets per second")]
    public float shootRate = 2;
    public float bulletSpeed = 15;
    public float damage = 1;
    public float resourceCost = 1;
    public float duration = 1;
    public float reloadTime = 5;

    [Header("Weapon Stats")]
    public float resources = 10;


    public abstract void shoot(KeyCode shootButton);

    public void pickup(WeaponShooter shooter) {
        shooter.weapons.Add(this);
    }
}
