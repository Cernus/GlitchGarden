using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    // Creates projectile GameObject from script. Does nothing if GameObject already exists.
    private void Start()
    {
        animator = GetComponent<Animator>();

        // Creates a parent if necessary
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    private void Update()
    {
        if(IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // Look through all spawners, and set myLaneSpawner if found
    private void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == this.transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
        return;
    }

    private bool IsAttackerAheadInLane()
    {
        // Exit if no attackers in lane
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        // Return true if there is an Attacker to the right of this Defender
        // (transforms also support enumerators so you can loop through children)
        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x > this.transform.position.x)
            {
                return true;
            }
        }

        // Attacker/s in lane but behind us
        return false;
    }

    private void Fire()
    {
        // Instantiate new projectile, parented to the Projectiles GameObject
        // (Instantiate is for prefabs)
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        // Sets projectile to the Projectiles game object
        newProjectile.transform.parent = projectileParent.transform;
        // Places the projectile at the correct place in the Game World
        newProjectile.transform.position = gun.transform.position;
    }

}
