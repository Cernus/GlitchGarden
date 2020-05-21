using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    // Update is called once per frame
    void Update ()
    {
        foreach(GameObject thisAttacker in attackerPrefabArray)
        {
            if(IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    private void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        // Child to this Spawner
        myAttacker.transform.parent = transform;
        // Spawn at position of Spawner
        myAttacker.transform.position = transform.position;
    }

    private bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold); // True or False

    }
}
