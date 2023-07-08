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

}