using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour
{

    [Header("Keybindings")]
    public KeyCode shootButton;
    public KeyCode cycleWeaponUp;
    public KeyCode cycleWeaponDown;
    public KeyCode reloadButton;

    [Header("Weapon information")]

    [SerializeField]
    public Weapon currWeapon;
    public List<Weapon> weapons;

    public Transform weaponPosition;

    public int currWeaponIndex = 0;
    public int maxWeapons = 5;

    void Update(){
        if (currWeapon == null){
            if (weapons.Count == 1){
                currWeapon = weapons[0];
                currWeapon.gameObject.SetActive(true);
            }
            return;
        }

        int val = (Input.GetKeyDown(cycleWeaponUp) ? 0 : 1) + (Input.GetKeyDown(cycleWeaponDown) ? 0 : -1);
        cycleWeapon(val);

        currWeapon.Update();
        currWeapon.shoot(shootButton);
    }

    void Start(){
        
    }

    void cycleWeapon(int movements) {
        currWeapon.gameObject.SetActive(false);
        currWeaponIndex = mod(currWeaponIndex + movements, weapons.Count);
        currWeapon = weapons[currWeaponIndex];
        currWeapon.gameObject.SetActive(true);
    }

    int mod(int x, int m){ //Stolen from https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain/1082938
        return (x % m + m) % m;
    }

    public void Add(Weapon weapon){
        if(weapons.Count >= maxWeapons){
            
            List<WeaponHolder> holders = new List<WeaponHolder>(this.GetComponentsInChildren<WeaponHolder>(true));
            //Debug.Log(holders.Count);
            WeaponHolder h = holders[currWeaponIndex];
            h.pickupCooldown = 2;
            Destroy(currWeapon.gameObject);
            weapons.RemoveAt(currWeaponIndex);

            Destroy(h.gameObject);
            //h.transform.parent = null;
            //h.gameObject.SetActive(true);
        }

        weapons.Add(weapon);
        currWeaponIndex = weapons.IndexOf(weapon);
        currWeapon = weapons[currWeaponIndex];
        currWeapon.transform.parent = weaponPosition;
        currWeapon.transform.localPosition = Vector3.zero;
            
    }

    int RandomSign (){
        return Random.Range(-1, 0) < .5? 1 : -1;
    }
}
