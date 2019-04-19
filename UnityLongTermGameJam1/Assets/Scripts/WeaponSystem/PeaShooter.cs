using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Weapon{

    public override void shoot(KeyCode shoot){
        
        if (this.canShoot == true){
            if (!Input.GetKey(shoot)) {
                return;
            }

            

            foreach (Transform t in shootPoints)
            {
                GameObject go = Instantiate(bullet, t.position, Quaternion.identity, null);
                DefaultBullet shot = go.GetComponent<DefaultBullet>();
                shot.direction = t.right;
                shot.speed = bulletSpeed;
            }

            base.shoot(shoot); //Always run this at the end when you shoot something
        }
    }

}
