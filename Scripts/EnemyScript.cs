using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    private Transform target;
    private int rageMeter = 8;
    private float canAttack;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;

    private void Update(){
        if (target != null && rageMeter >= 10){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            if (attackSpeed <= canAttack){
                other.gameObject. GetComponent<PlayerHealth>() .UpdateHealth(-attackDamage) ;
                canAttack = 0f;
            }
            else{
                canAttack += Time.deltaTime;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
           target = other.transform;
           rageMeter++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
           target = null;
        }
    }
}
