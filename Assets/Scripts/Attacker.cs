using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    //[Range (-1f, 1.5f)] 
    private float currentSpeed;
    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        // Adds rigid body to this Attacker
        //Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidBody.isKinematic = true;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Distance = speed x time
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        // If there is no current target (enemy has been destroyed)
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + " trigger enter");
    }

    public void setSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Puts Attacker into attack mode
    public void Attack(GameObject obj)
    {
        currentTarget = obj;

    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if(currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
        
        //Debug.Log(name + " caused damage: " + damage);
    }
}
