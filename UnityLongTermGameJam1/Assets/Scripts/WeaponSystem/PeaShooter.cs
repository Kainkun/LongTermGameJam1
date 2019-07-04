using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Weapon{

    public AudioClip ShotSound;

    public override void shoot(KeyCode shoot){
        

        if (this.canShoot == true){
            if (!Input.GetButton("Fire") || Time.timeScale == 0) {
                return;
            }

            

            foreach (Transform t in shootPoints)
            {
                GameObject go = Instantiate(bullet, t.position, Quaternion.identity, null);
                DefaultBullet shot = go.GetComponent<DefaultBullet>();
                shot.direction = t.right;
                shot.speed = bulletSpeed;
            }

            BulletSound soundScript = GameObject.FindWithTag("Player").GetComponent<BulletSound>(); // get script that plays bullet sound
            if(ShotSound != null)
            soundScript.CyberpunkGunshot = ShotSound; //set sound
            soundScript.playSound();

            base.shoot(shoot); //Always run this at the end when you shoot something
        }
    }

    public override void shoot(){
        
        if (this.canShoot == true){
            foreach (Transform t in shootPoints)
            {
                GameObject go = Instantiate(bullet, t.position, Quaternion.identity, null);
                DefaultBullet shot = go.GetComponent<DefaultBullet>();
                shot.direction = t.right;
                shot.speed = bulletSpeed;
            }

            if (GameObject.FindWithTag("Player") != null)
            {
                BulletSound soundScript = GameObject.FindWithTag("Player").GetComponent<BulletSound>(); // get script that plays bullet sound
                soundScript.CyberpunkGunshot = ShotSound; //set sound
                soundScript.playSound();
            }

            base.shoot(); //Always run this at the end when you shoot something
        }
    }

}
