using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] SpriteRenderer bulletGFX;
    [SerializeField] Transform gun;
    bool CanFire = true;
    float reload = 2;

    private void Start() {
        
    }

    private void Update() {
        if(Input.GetMouseButton(0) && CanFire){
            FireGun();
            CanFire = false;
        }
        if(reload > 0){
            reload -= 1f*Time.deltaTime;
        }
        else if(reload == 0){
            CanFire = true;
        }
    }

    void FireGun(){
        float BulletVelocity = 3;
        float angle = Utility.AngleTowardsMouse(gun.position);
        Quaternion rot = Quaternion. Euler (new Vector3(0f, 0f, angle)) ;
        Bullet Bullet = Instantiate(bullet, gun.position, rot).GetComponent<Bullet>();
        Bullet.BulletVelocity = BulletVelocity;
    }
}
