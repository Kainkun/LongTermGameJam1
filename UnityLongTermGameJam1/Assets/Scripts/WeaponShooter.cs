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
        currWeapon.shoot(shootButton);
    }

    void cycleWeapon(int movements) {
        currWeaponIndex = currWeaponIndex + movements % weapons.Count;
        currWeapon = weapons[currWeaponIndex];
    }
}
