using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class RifleAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gun;
    bool CanFire = true;
    float reload = 0;

    private void Start() {
        
    }

    private void Update() {
        if(Input.GetMouseButton(0) && CanFire){
            StartCoroutine(RifleShoot());
            reload = 4;
        }
        if(reload > 0){
            reload -= 1f*Time.deltaTime;
        }
        else if(reload <= 0){
            CanFire = true;
        }
    }

    IEnumerator RifleShoot(){
        for (int i = 0; i<5; i++){
            FireGun();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void FireGun(){
        float BulletSpeed = 3;
        float angle = Utility.AngleTowardsMouse(gun.position);
        Quaternion rot = Quaternion. Euler (new Vector3(0f, 0f, angle - 90)) ;
        Bullet Bullet = Instantiate(bulletPrefab, gun.position, rot).GetComponent<Bullet>();
        Bullet.BulletVelocity = BulletSpeed;
        CanFire = false;
    }

}