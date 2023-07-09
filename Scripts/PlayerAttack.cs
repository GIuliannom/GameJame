using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public abstract class PlayerAttack : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform gun;
    public bool CanFire = true;
    public float reload = 0;

    public abstract void Shoot();

    public void FireGun(){
        float BulletSpeed = 3;
        float angle = Utility.AngleTowardsMouse(gun.position);
        Quaternion rot = Quaternion. Euler (new Vector3(0f, 0f, angle - 90)) ;
        Bullet Bullet = Instantiate(bulletPrefab, gun.position, rot).GetComponent<Bullet>();
        Bullet.BulletVelocity = BulletSpeed;
        CanFire = false;
        reload = 1;
    }

}