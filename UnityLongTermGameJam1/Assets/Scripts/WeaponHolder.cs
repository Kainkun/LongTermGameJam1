using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    
    [SerializeField]
    float lookupTag;

    [SerializeField]
    [Tooltip("Add the weapon onto this object!")]
    Weapon weapon;

    Collider2D coll;

    private void Start()
    {
        if (weapon == null){
            weapon = this.gameObject.AddComponent<Weapon>();
        } else {
            weapon = this.GetComponent<Weapon>();
        }

        if (coll == null){
            coll = this.gameObject.AddComponent<Collider2D>();
        } else {
            coll = this.GetComponent<Collider2D>();
        }
    }

    //TODO :: do pickup check
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(lookupTag)) {
            WeaponShooter shooter = collision.GetComponent<WeaponShooter>();
            if (shooter == null){ //check children
                shooter = collision.GetComponentInChildren<WeaponShooter>();
            }

            GameObject weaponObj = new GameObject();
            Weapon w = weaponObj.AddComponent<Weapon>();
            

            weaponObj.transform.parent = shooter.transform;
            foreach(Transform t in weapon.shootPoints) {
                t.parent = weaponObj.transform;
            }
        }
    }
}
