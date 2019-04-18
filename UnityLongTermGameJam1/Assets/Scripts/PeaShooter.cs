using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Weapon{

    bool canShoot = true;
    
    public override void shoot(KeyCode shoot){
        if(canShoot == true){
            canShoot = false;
            StartCoroutine(timer(1000 / shootRate));
        }
    }

    IEnumerator timer(float time2wait) {
        yield return new WaitForSeconds(time2wait);
        canShoot = true;
    }
}
