using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] SpriteRenderer bulletGFX;
    [SerializeField] Transform gun;
    bool CanFire = true;
    float reload = 0;

    private void Start() {
        
    }

    private void Update() {
        if(Input.GetMouseButton(0) && CanFire){
            FireGun();
            Debug.Log("fire");
        }
        if(reload > 0){
            reload -= 1f*Time.deltaTime;
        }
        else if(reload <= 0){
            CanFire = true;
        }
    }

    void FireGun(){
        float BulletSpeed = 3;
        float angle = Utility.AngleTowardsMouse(gun.position);
        Quaternion rot = Quaternion. Euler (new Vector3(0f, 0f, angle - 90)) ;
        Bullet Bullet = Instantiate(bulletPrefab, gun.position, rot).GetComponent<Bullet>();
        Bullet.BulletVelocity = BulletSpeed;
        CanFire = false;
        reload = 1;
        Debug.Log("2");
    }

}