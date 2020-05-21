using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If ever add Fox.cs to a game object then Unity will check to see if we have also got Attacker.cs
[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;
    
    // Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
         GameObject obj = collision.gameObject;

        // If the collided object does not have Defender Script
        if(!obj.GetComponent<Defender>())
        {
            return;
        }

        // If Fox collides with Stone - jump
        if (obj.GetComponent<GraveStone>())
        {
            animator.SetTrigger("jump trigger");
        }
        // Otherwise go into attack mode
        else
        {
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }

        //Debug.Log("fox collided with " + collision);

    }
}
