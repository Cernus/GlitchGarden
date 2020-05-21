using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private SceneLoader sceneLoader;

    // Use this for initialization
    void Start ()
    {
		sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
    }
	

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        sceneLoader.LoadLoseScene();
    }
}
