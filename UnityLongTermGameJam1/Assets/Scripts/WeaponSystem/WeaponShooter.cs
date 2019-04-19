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

    int currWeaponIndex = 0;

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
}
