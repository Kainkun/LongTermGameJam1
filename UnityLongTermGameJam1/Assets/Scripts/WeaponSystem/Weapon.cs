using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour{

    public Sprite sprite;
    public Transform[] shootPoints;
    private SpriteRenderer render;
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

    public bool canShoot = false;
    public float timeUntilCanShoot = 0;

    public void Start(){

        render = this.GetComponent<SpriteRenderer>();
        render.sprite = sprite;
    }

    public void Update(){
        timeUntilCanShoot -= Time.deltaTime;

        if (timeUntilCanShoot < 0)
        {
            canShoot = true;
        }
    }

    public virtual void shoot(KeyCode shootButton) {
        canShoot = false;
        timeUntilCanShoot = 1 / shootRate;
    }

    public virtual void shoot() {
        canShoot = false;
        timeUntilCanShoot = 1 / shootRate;
    }

    public void pickup(WeaponShooter shooter) {
        shooter.weapons.Add(this);
    }

    public void Clone(Weapon w) {
        this.sprite = w.sprite;
        this.shootPoints = (Transform[])w.shootPoints.Clone();
        this.bullet = w.bullet;

        this.shootRate = w.shootRate;
        this.bulletSpeed = w.bulletSpeed;
        this.damage = w.damage;
        this.resourceCost = w.resourceCost;
        this.duration = w.duration;
        this.reloadTime = w.reloadTime;

        this.resources = w.resources;
    }
}
