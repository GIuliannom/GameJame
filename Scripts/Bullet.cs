using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float BulletVelocity;

    [SerializeField] Rigidbody2D rb;

    private void Start(){
        Destroy(gameObject, 4f);
    }

    private void FixedUpdate() {
        rb.velocity = transform.up*BulletVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
