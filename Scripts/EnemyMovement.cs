using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    private float maxRange = 5f;
    private float minRange = 0.75f;
    public Transform player;
    private Rigidbody2D rb;
    private Animator anim;

    /* [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform gun;
    public bool CanFire = true;
    public float reload = 0; */

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

        if (player != null && Vector3.Distance(player.position, transform.position) <= maxRange && Vector3.Distance(player.position, transform.position)>=minRange)
        {
            FollowPlayer();
            //Shoot();
        }
        else if (player != null && Vector3.Distance(player.position, transform.position) == minRange)
        {
            StopFollow();
        }
        else    
        {
            StopFollow();
        }
        FlipCharacter();
    }

    public void FollowPlayer()
    {
        anim.SetBool("IsRunning", true);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void StopFollow()
    {
        anim.SetBool("IsRunning", false);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0f * Time.deltaTime);
    }

    public void FlipCharacter()
    {
        bool flipped = player.transform.position.x < 0;
        transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }
    /* public void Shoot(){
        if(CanFire){
            FireGun();
            reload = 0.5f;
        }
        if(reload > 0){
            reload -= 1f*Time.deltaTime;
        }
        else if(reload <= 0){
            CanFire = true;
        }
    }

    public void FireGun(){
        float BulletSpeed = 3;
        Vector3 targetDir = player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        Quaternion rot = Quaternion. Euler (new Vector3(0f, 0f, angle)) ;
        Bullet Bullet = Instantiate(bulletPrefab, gun.position, rot).GetComponent<Bullet>();
        Bullet.BulletVelocity = BulletSpeed;
        CanFire = false;
        reload = 1;
    } */
}