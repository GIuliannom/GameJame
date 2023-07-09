using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : PlayerAttack
{
    public Transform player;
    bool hasPlayer = false;
    bool beingCarried = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.tag == "Hand"){
           hasPlayer = true;
           Debug.Log("Collision");
        }
    }   

    private void OnTriggerExit2D(Collider2D other)
    {
	    hasPlayer = false;
    }	

    void Update()
    {
	    if(beingCarried)
	    {
            //Drop weapon
		    if(Input.GetKeyDown("space"))
		    {
			    transform.parent = null;
			    beingCarried = false;
		    }

            Shoot();
	    }
	    else
	    {
            //Check if inside "hand" hitbox, if yes and pressed space pick up gun
		    if(Input.GetKeyDown("space") && hasPlayer)
		    {
			    transform.parent = player;
			    beingCarried = true;
		    }
	    }
    }

    public override void Shoot(){
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
}
