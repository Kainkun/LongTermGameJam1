using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    
    [SerializeField]
    string lookupTag;

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
        if (collision.tag.ToLower().Equals(lookupTag.ToLower())) {
            WeaponShooter shooter = collision.GetComponent<WeaponShooter>();
            if (shooter == null){ //check children
                shooter = collision.GetComponentInChildren<WeaponShooter>();
            }

            GameObject weaponObj = Instantiate(this.transform.GetChild(0).gameObject, shooter.transform.position, Quaternion.identity, shooter.transform);
            Weapon w = weaponObj.gameObject.GetComponent<Weapon>();

            weaponObj.SetActive(false);
            Destroy(this.gameObject);

            shooter.weapons.Add(w);
        }
    }
}
